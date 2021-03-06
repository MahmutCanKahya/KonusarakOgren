﻿using KonusarakOgren.Quiz.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Quiz.MvcWebUI.Models
{
    public class PostListModel
    {
        public PostListModel()
        {
            this.TrueAnswers = new string[4];
        }
        public List<Exam> Exams { get; set; }
        public Exam Exam { get; set; }
        public string[] TrueAnswers { get; set; }

    }
}
