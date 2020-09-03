using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KonusarakOgren.Quiz.MvcWebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını doldurunuz.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi doldurunuz.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
