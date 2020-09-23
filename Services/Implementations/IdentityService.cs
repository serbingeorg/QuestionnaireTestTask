using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QuestionnareTestTask.Models;
using QuestionnareTestTask.Options;
using QuestionnareTestTask.Repositories.Interfaces;
using QuestionnareTestTask.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QuestionnareTestTask.Services.Implementations
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly ITokenRepository _tokenRepository;
        public IdentityService(
             UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            JwtSettings jwtSettings,
            TokenValidationParameters tokenValidationParameters,
            ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
            _tokenRepository = tokenRepository;
        }
        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new AuthenticationResult()
                {
                    Errors = new[] { "User does not exist" }
                };
            }
            var userHasValidPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!userHasValidPassword)
            {
                return new AuthenticationResult()
                {
                    Errors = new string[] { "User/password combination is wrong" }
                };
            }
            return await GenerateAuthenticationResultForUserAsync(user);
        }

        public async Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            var validatedToken = GetPrincipalFromToken(token);
            if (validatedToken == null)
            {
                return new AuthenticationResult() { Errors = new[] { "Invalid token error" } };
            }
            var expiryDateTimeUnix = long.Parse(validatedToken.Claims.Single(i => i.Type == JwtRegisteredClaimNames.Exp).Value);
            var expiryDateTimeUts = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(expiryDateTimeUnix);
            if (expiryDateTimeUts > DateTime.UtcNow)
            {
                return new AuthenticationResult() { Errors = new[] { "Token hasn't expired yet" } };
            }
            var jti = validatedToken.Claims.Single(i => i.Type == JwtRegisteredClaimNames.Jti).Value;
            var storedRefreshTokent = await _tokenRepository.GetAsync(i => i.Token == refreshToken);
            if (storedRefreshTokent == null)
            {
                return new AuthenticationResult() { Errors = new[] { "Refresh token doesn't exist" } };
            }
            if (DateTime.UtcNow > storedRefreshTokent.ExpiryDate)
            {
                return new AuthenticationResult() { Errors = new[] { "Refresh token has expired" } };
            }
            if (storedRefreshTokent.IsInvalidated)
            {
                return new AuthenticationResult() { Errors = new[] { "Refresh token has been invalidated" } };
            }
            if (storedRefreshTokent.IsUsed)
            {
                return new AuthenticationResult() { Errors = new[] { "Refresh token has been used" } };
            }
            if (storedRefreshTokent.JwtId != jti)
            {
                return new AuthenticationResult() { Errors = new[] { "Refresh token doesn't match this JWT" } };
            }
            storedRefreshTokent.IsUsed = true;
            await _tokenRepository.UpdateAsync(storedRefreshTokent);
            var user = await _userManager.FindByIdAsync(validatedToken.Claims.Single(i => i.Type == "id").Value);
            return await GenerateAuthenticationResultForUserAsync(user);
        }

        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                return new AuthenticationResult()
                {
                    Errors = new[] { "User with this email address already exists" }
                };
            }
            var newUserId = Guid.NewGuid().ToString();
            var newUser = new IdentityUser()
            {
                Id = newUserId,
                Email = email,
                UserName = email
            };
            var createdUser = await _userManager.CreateAsync(newUser, password);
            if (!createdUser.Succeeded)
            {
                return new AuthenticationResult()
                {
                    Errors = createdUser.Errors.Select(i => i.Description)
                };
            }
            await _userManager.AddClaimAsync(newUser, new Claim("post.view", "true"));
            return await GenerateAuthenticationResultForUserAsync(newUser);
        }

        #region private methods

        private ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }
                else
                {
                    return principal;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken token)
        {
            return (token is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase);
        }
        private async Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("id", user.Id)
            };
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role == null) continue;
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                foreach (var roleClaim in roleClaims)
                {
                    if (claims.Contains(roleClaim))
                        continue;

                    claims.Add(roleClaim);
                }
            }
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.Add(_jwtSettings.Tokenlifetime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var refreshToken = new RefreshToken()
            {
                //Token = Guid.NewGuid().ToString(), //TODO:  this is shit to change
                JwtId = token.Id,
                UserId = user.Id,
                CreationDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(_jwtSettings.RefreshTokenLifeMonths)
            };
            await _tokenRepository.AddAsync(refreshToken);
            return new AuthenticationResult()
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }
        #endregion
    }
}
