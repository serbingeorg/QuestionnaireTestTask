﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionnareTestTask.ApiContracts.Request
{
    public class QuestionnaireRequest
    {
        public string Name { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}
