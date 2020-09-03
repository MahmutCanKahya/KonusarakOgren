using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.Business.Abstract
{
    public interface IExamService
    {

        List<Exam> GetAll();
        Exam GetById(int examId);
        int Add(Exam exam);
        void Update(Exam exam);
        void Delete(int examId);
        Exam FindExamByIdIncludeQuestionsAndAnswers(int examId);
    }
}
