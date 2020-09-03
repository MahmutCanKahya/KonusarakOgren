using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using KonusarakOgren.Quiz.Entities.Concrete;
using KonusarakOgren.Quiz.MvcWebUI.Helpers;
using KonusarakOgren.Quiz.MvcWebUI.Models;

namespace KonusarakOgren.Quiz.MvcWebUI.Controllers
{
    public class QuizCreateController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new PostListModel();
            model.Posts= await HtmlScrap.GetHtmlAsync();
            return View(model);
        }
    }
}
