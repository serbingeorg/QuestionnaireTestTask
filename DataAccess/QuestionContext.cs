using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireTestTask.Models
{
    public class QuestionContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Person> People { get; set; }
         public DbSet<Questionnaire> Questionnaires { get; set; }

        public QuestionContext(DbContextOptions<QuestionContext> options)
            : base(options)
        {
           Database.EnsureCreated();
        }
    }
}
