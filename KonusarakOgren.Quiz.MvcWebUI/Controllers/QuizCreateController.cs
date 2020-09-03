using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KonusarakOgren.Quiz.Entities.Concrete;
using KonusarakOgren.Quiz.MvcWebUI.Helpers;
using KonusarakOgren.Quiz.MvcWebUI.Models;
using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.DataAccess.Concrete.EntityFramework;

namespace KonusarakOgren.Quiz.MvcWebUI.Controllers
{
    public class QuizCreateController : Controller
    {
        IExamService _examService;
        IQuestionService _questionService;
        IAnswerService _answerService;

        public QuizCreateController(IExamService examService, IQuestionService questionService, IAnswerService answerService)
        {
            _examService = examService;
            _questionService = questionService;
            _answerService = answerService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new PostListModel();
            model.Exams= await HtmlScrap.GetHtmlAsync();
            return View(model);
        }

        [HttpPost]
        public ActionResult CompleteExam(PostListModel model)
        {
            if (ModelState.IsValid)
            {
                Exam exam = new Exam
                {
                    ExamCreateDate = new DateTime(),
                    ExamTitle = "Deneme sınavı",
                    ExamText = "denemedenemedenemedenemedenemedenemedenemedenemedenemedenemedenemedenemedeneme",
                    Questions = new List<Question>()
                    {
                        new Question
                        {
                            QuestionText="Soru1",
                            Answers=new List<Answer>()
                            {
                               new Answer
                               {
                                   AnswerText="Cevap 1",
                                   IsTrue=true,
                               },
                               new Answer
                               {
                                   AnswerText="Cevap 2",
                                   IsTrue=false,
                               },
                               new Answer
                               {
                                   AnswerText="Cevap 3",
                                   IsTrue=false,
                               },
                               new Answer
                               {
                                   AnswerText="Cevap 4",
                                   IsTrue=false,
                               }
                            }
                        },
                        new Question
                        {
                            QuestionText="Soru2",
                            Answers=new List<Answer>()
                            {
                               new Answer
                               {
                                   AnswerText="Cevap 1",
                                   IsTrue=false,
                               },
                               new Answer
                               {
                                   AnswerText="Cevap 2",
                                   IsTrue=false,
                               },
                               new Answer
                               {
                                   AnswerText="Cevap 3",
                                   IsTrue=false,
                               },
                               new Answer
                               {
                                   AnswerText="Cevap 4",
                                   IsTrue=true,
                               }
                            }
                        }
                    }
                };


                int examId=_examService.Add(exam);
                foreach (var question in exam.Questions)
                {
                    question.ExamId = examId;
                    int questionId=_questionService.Add(question);
                    foreach (var answer in question.Answers)
                    {
                        answer.QuestionId = questionId;
                        _answerService.Add(answer);
                    }
                }
                return RedirectToAction("Index","QuizCreate");

               
            }

            return View();
        }
    }
}
