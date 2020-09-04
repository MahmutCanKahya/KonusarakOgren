using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Quiz.Entities
{
    public class QuestionAnswerRequest
    {
        public int QuestionId { get; set; }
        public int MarkedAnswerId { get; set; }
    }
}
