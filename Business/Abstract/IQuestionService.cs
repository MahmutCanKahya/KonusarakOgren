using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.Business.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetByExamId(int examId);
        int Add(Question question);
        void Update(Question question);
        void Delete(int questionId);
    }
}
