using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonusarakOgren.Quiz.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace KonusarakOgren.Quiz.MvcWebUI.ViewComponents
{
    public class QuestionListViewComponent : ViewComponent
    {
        public ViewViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
