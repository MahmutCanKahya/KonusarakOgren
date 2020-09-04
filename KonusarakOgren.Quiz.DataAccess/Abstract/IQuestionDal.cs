using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Quiz.Entities;
using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.DataAccess.Abstract
{
    public interface IQuestionDal:IEntityRepository<Question>
    {
        QuestionAnswerResponse CheckQuestionAnswer(QuestionAnswerRequest request);
    }
}
