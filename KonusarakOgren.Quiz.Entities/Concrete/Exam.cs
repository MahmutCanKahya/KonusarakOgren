using KonusarakOgren.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KonusarakOgren.Quiz.Entities.Concrete
{
    public class Exam:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExamId { get; set; }
        public string ExamTitle { get; set; }
        public string ExamText { get; set; }
        public DateTime ExamCreateDate { get; set; }

        public virtual List<Question> Questions { get; set; }
    }
}
