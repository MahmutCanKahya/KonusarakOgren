using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();

        User Login(string userName,string password);
    }
}
