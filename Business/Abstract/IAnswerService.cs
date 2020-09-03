using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.Business.Abstract
{
    public interface IAnswerService
    {
        List<Answer> GetByQuestionId(int questionId);
        int Add(Answer answer);
        void Update(Answer answer);
        void Delete(int answerId);
    }
}
