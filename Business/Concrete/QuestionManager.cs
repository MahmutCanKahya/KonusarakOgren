using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.DataAccess.Abstract;
using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.Business.Concrete
{
    public class QuestionManager:IQuestionService
    {
        IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public int Add(Question question)
        {
            _questionDal.Add(question);
            return question.QuestionId;
        }

        public void Delete(int questionId)
        {
            _questionDal.Delete(new Question { QuestionId = questionId });
        }

        public List<Question> GetByExamId(int examId)
        {
            return _questionDal.GetList(q => q.ExamId==examId);
        }

        public void Update(Question question)
        {
            _questionDal.Update(question);
        }

    }
}
