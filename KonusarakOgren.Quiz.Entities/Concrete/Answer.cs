using KonusarakOgren.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KonusarakOgren.Quiz.Entities.Concrete
{
    public class Answer:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerId { get; set; }
        [Required]
        public string AnswerText { get; set; }
        public bool IsTrue { get; set; }

        
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId ")]
        public Question Question { get; set; }
    }
}
