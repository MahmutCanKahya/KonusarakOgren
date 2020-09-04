using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Quiz.MvcWebUI.Models
{
    public class QuestionAnswerResponseModel
    {
        public int QuestionId { get; set; }
        public int MarkedAnswerId { get; set; }
        public bool IsTrue { get; set; }
    }
}
