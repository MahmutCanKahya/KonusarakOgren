using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.Quiz.DataAccess.Abstract;
using KonusarakOgren.Quiz.Entities;
using KonusarakOgren.Quiz.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Internal;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KonusarakOgren.Quiz.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionDal : EfEntityRepositoryBase<Question, QuizDbContext>, IQuestionDal
    {
        IAnswerDal _answerDal;

        public EfQuestionDal(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }

        public QuestionAnswerResponse CheckQuestionAnswer(QuestionAnswerRequest request)
        {

            var question = Get(x => x.QuestionId == request.QuestionId);
            var response = new QuestionAnswerResponse()
            {
                MarkedAnswerId = _answerDal.GetList(x => x.QuestionId == request.QuestionId).FirstOrDefault(x => x.IsTrue == true).AnswerId,
                IsTrue = _answerDal.GetList(x => x.QuestionId == request.QuestionId).Any(x => x.IsTrue == true && x.AnswerId == request.MarkedAnswerId),
                QuestionId = question.QuestionId
            };

            return response;
        }
    }
}
