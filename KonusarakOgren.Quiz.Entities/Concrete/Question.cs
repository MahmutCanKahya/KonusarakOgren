using KonusarakOgren.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KonusarakOgren.Quiz.Entities.Concrete
{
    public class Question:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int ExamId { get; set; }
        [ForeignKey("ExamId ")]
        public Exam Exam { get; set; }
        
        public ICollection<Answer> Answers { get; set; }
        

    }
}
