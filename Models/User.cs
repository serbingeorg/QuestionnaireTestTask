﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnaireTestTask.Models  
{
    public class User 
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public int Age { get; set; }
        public  ICollection<Questionnaire> Questionnaires { get; set; }
        public User()
        {
            Questionnaires = new List<Questionnaire>();
        }

    }
}
