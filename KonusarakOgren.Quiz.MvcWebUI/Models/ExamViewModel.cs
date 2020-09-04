using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Quiz.MvcWebUI.Models
{
    public class ExamViewModel
    {
        public ExamViewModel()
        {
            MarkedAnswers = new Dictionary<int, int>();
        }
       
        public Exam Exam { get; set; }
        //first int=>question id,,,,, second int=> marked answer id
        public Dictionary<int, int> MarkedAnswers { get; set; }
    }
}
