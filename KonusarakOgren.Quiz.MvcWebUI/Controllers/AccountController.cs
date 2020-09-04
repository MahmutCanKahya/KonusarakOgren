using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.MvcWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.Quiz.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result =_userService.Login(loginViewModel.UserName, loginViewModel.Password);
                if (result!=null)
                {
                    if (result.RoleType == 1)
                    {
                        return RedirectToAction("CreateExam", "Exam");
                    }
                    if (result.RoleType == 2)
                    {
                        //return RedirectToAction("Index", "Quiz");
                    }
                    
                }
                
                ModelState.AddModelError("", "Geçersiz kullanıcı. Tekrar giriş yapın.");
            }
            return View(loginViewModel);
        }

        
    }
}
