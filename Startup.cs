using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using QuestionnaireTestTask.Models;


namespace QuestionnareTestTask
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<QuestionContext>(opt =>
            opt.UseInMemoryDatabase("Questionnaire_DB"));
            services.AddControllers();
            services.AddSwaggerGen();
                //c =>
                //{
                //    c.SwaggerDoc("v1", new OpenApiInfo
                //    {
                //        Version = "v1",
                //        Title = "ToDo API",
                //        Description = "A simple example ASP.NET Core Web API",
                //        TermsOfService = new Uri("https://example.com/terms"),
                //        Contact = new OpenApiContact
                //        {
                //            Name = "Shayne Boyer",
                //            Email = string.Empty,
                //            Url = new Uri("https://twitter.com/spboyer"),
                //        },
                //        License = new OpenApiLicense
                //        {
                //            Name = "Use under LICX",
                //            Url = new Uri("https://example.com/license"),
                //        }
                //    });
                //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Questionnaire");
                //c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
