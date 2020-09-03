using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.DataAccess.Abstract;
using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.Business.Concrete
{
    public class AnswerManager : IAnswerService
    {
        private IAnswerDal _answerDal;

        public AnswerManager(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }
        public int Add(Answer answer)
        {
            _answerDal.Add(answer);
            return answer.AnswerId;
        }

        public void Delete(int answerId)
        {
            _answerDal.Delete(new Answer { AnswerId = answerId });
        }

        public List<Answer> GetByQuestionId(int questionId)
        {
           return _answerDal.GetList(a => a.QuestionId == questionId);
        }

        public void Update(Answer answer)
        {
            _answerDal.Update(answer);
        }
    }
}
