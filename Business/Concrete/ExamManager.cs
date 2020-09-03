using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.DataAccess.Abstract;
using KonusarakOgren.Quiz.DataAccess.Concrete.EntityFramework;
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
            _examDal.Add(exam);
            return exam.ExamId;
        }

        public void Update(Exam exam)
        {
            _examDal.Update(exam);
        }

        public void Delete(int examId)
        {
            /*foreach (var question in exam.Questions)
            {
                foreach (var answer in question.Answers)
                {
                    _answerService.Delete(answer.AnswerId);
                }
                _questionService.Delete(question.QuestionId);
            }*/
           //_examDal.Delete(exam);
            _examDal.Delete(new Exam { ExamId = examId });
        }

        public Exam FindExamByIdIncludeQuestionsAndAnswers(int examId)
        {
            
            var exam = _examDal.Get(p=>p.ExamId==examId);
            var questions=exam.Questions = _questionDal.GetList()
                .Where(question =>
                question.Exam != null && question.Exam.ExamId == exam.ExamId)
                .ToList();
            foreach (var answer in questions)
            {
                answer.Answers = _answerDal.GetList()
                    .Where(answer =>
                    answer.Question != null && answer.Question.QuestionId == answer.QuestionId)
                    .ToList();
            }
            return exam;
        }
    }
}
