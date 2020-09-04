using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.DataAccess.Abstract;
using KonusarakOgren.Quiz.DataAccess.Concrete.EntityFramework;
using KonusarakOgren.Quiz.Entities;
using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KonusarakOgren.Quiz.Business.Concrete
{
    public class ExamManager : IExamService
    {
        private IExamDal _examDal;
        private IAnswerDal _answerDal;
        private IQuestionDal _questionDal;

        public ExamManager(IExamDal examDal, IAnswerDal answerDal, IQuestionDal questionDal)
        {
            _examDal = examDal;
            _answerDal = answerDal;
            _questionDal = questionDal;
        }

        public Exam GetById(int examId)
        {
            return _examDal.Get(p => p.ExamId == examId);
        }
        public List<Exam> GetAll()
        {
            return _examDal.GetList();
        }

        public int Add(Exam exam)
        {
            exam.ExamCreateDate = DateTime.Today;
            _examDal.Add(exam);
            int examId = exam.ExamId;
            foreach (var question in exam.Questions)
            {
                question.ExamId = examId;
                _questionDal.Add(question);
                int questionId = question.QuestionId;
                foreach (var answer in question.Answers)
                {
                    answer.QuestionId = questionId;
                    _answerDal.Add(answer);
                }
            }
            return exam.ExamId;
        }

        public void Update(Exam exam)
        {
            _examDal.Update(exam);
        }

        public void Delete(int examId)
        {
            var exam = _examDal.Get(p => p.ExamId == examId);
            var questions = exam.Questions = _questionDal.GetList()
                .Where(question => question.ExamId == examId)
                .ToList();
            foreach (var question in questions)
            {
                var answers = question.Answers = _answerDal.GetList()
                    .Where(p => p.QuestionId == question.QuestionId)
                    .ToList();
                foreach (var answer in answers)
                {
                    _answerDal.Delete(answer);
                }
                _questionDal.Delete(question);
            }
           _examDal.Delete(exam);
           // _examDal.Delete(new Exam { ExamId = examId });
        }

        public Exam FindExamByIdIncludeQuestionsAndAnswers(int examId)
        {
            
            var exam = _examDal.Get(p=>p.ExamId==examId);
            var questions=exam.Questions = _questionDal.GetList()
                .Where(question =>question.ExamId==examId)
                .ToList();
            foreach (var question in questions)
            {
                question.Answers = _answerDal.GetList()
                    .Where(p => p.QuestionId== question.QuestionId)
                    .ToList();
            }
            return exam;
        }
        public List<QuestionAnswerResponse> CheckQuestionAnswers(List<QuestionAnswerRequest> request)
        {
            var response = new List<QuestionAnswerResponse>();

            foreach (var questionAnswer in request)
            {
                var correctAnswer = _questionDal.CheckQuestionAnswer(questionAnswer);

                response.Add(correctAnswer);
            }

            return response;
        }
    }
}
