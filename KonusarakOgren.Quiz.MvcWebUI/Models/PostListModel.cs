﻿using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Quiz.MvcWebUI.Models
{
    public class PostListModel
    {
        public List<Exam> Exams { get; set; }
        public Question Question { get; set; }
        public Answer Answer { get; set; }

    }
}
