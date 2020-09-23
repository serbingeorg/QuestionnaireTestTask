using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using QuestionnareTestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireTestTask.Models
{
    public class QuestionnaireDBContext : IdentityDbContext <IdentityUser>
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public QuestionnaireDBContext(DbContextOptions options)
            : base(options)
        {
           //Database.EnsureCreated();
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
          
        }
    }
}
