using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.Quiz.MvcWebUI.Controllers
{
    public class ExamController : Controller
    {
        IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ExamList()
        {
            var exams=_examService.GetAll();
            var model = new ExamListViewModel {
                Exams = exams
            };
            return View(model);
        }
        public IActionResult Remove(int examId)
        {
            _examService.FindExamByIdIncludeQuestionsAndAnswers(examId);
           // _examService.Delete(examId);
            return RedirectToAction("ExamList");
        }
    }
}
