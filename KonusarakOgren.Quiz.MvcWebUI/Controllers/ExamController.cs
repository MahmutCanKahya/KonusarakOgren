using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.Entities;
using KonusarakOgren.Quiz.Entities.Concrete;
using KonusarakOgren.Quiz.MvcWebUI.Helpers;
using KonusarakOgren.Quiz.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KonusarakOgren.Quiz.MvcWebUI.Controllers
{
    public class ExamController : Controller
    {
        IExamService _examService;
        List<string> options = new List<string>
            {
                "A","B","C","D"
            };

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        public async Task<IActionResult> CreateExam()
        {
           
            ViewBag.Options = new SelectList(options);
            var model = new PostListModel();
            model.Exams = await HtmlScrap.GetHtmlAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> CreateExam(PostListModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Options = new SelectList(options);
                model.Exams = await HtmlScrap.GetHtmlAsync();
                model.TrueAnswers = new string[4];
                return View(model);
            }
            Exam exam = model.Exam;
            string[] trueAnswerList = model.TrueAnswers;
            int i = 0;
            foreach (var question in exam.Questions)
            {
                int j = 0;
                foreach (var answer in question.Answers)
                {
                    if (trueAnswerList[i] == "A")
                    {
                        question.Answers[0].IsTrue = true;
                    }
                    if (trueAnswerList[i] == "B")
                    {
                        question.Answers[1].IsTrue = true;

                    }
                    if (trueAnswerList[i] == "C")
                    {

                        question.Answers[2].IsTrue = true;
                    }
                    if (trueAnswerList[i] == "D")
                    {

                        question.Answers[3].IsTrue = true;
                    }
                    j++;
                }

                i++;
            }
            _examService.Add(exam);
            return RedirectToAction("CreateExam", "Exam");
            
        }
        public ActionResult ExamList()
        {
            var exams = _examService.GetAll();
            var model = new ExamListViewModel
            {
                Exams = exams
            };
            return View(model);
        }
        public ActionResult Remove(int examId)
        {
            _examService.Delete(examId);
            return RedirectToAction("ExamList");
        }
        public ActionResult EnterExam(int examId)
        {
            var lExam = _examService.FindExamByIdIncludeQuestionsAndAnswers(examId);
            var model = new ExamViewModel
            {
                Exam = lExam
            };
            return View(model);
        }
        public ActionResult OnClickAnswer(int answerId, int questionId)
        {
            var markedAnswers = new Dictionary<int, int>();
            markedAnswers.Add(questionId, answerId);
            var model = new ExamViewModel
            {
                MarkedAnswers = markedAnswers
            };
            return View(model);
        }
        public List<QuestionAnswerResponse> CheckQuestionAnswers(List<QuestionAnswerRequest> request)
        {
            return _examService.CheckQuestionAnswers(request);
        }
    }
}
