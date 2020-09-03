using KonusarakOgren.Quiz.Business.Abstract;
using KonusarakOgren.Quiz.DataAccess.Abstract;
using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User Login(string userName, string password)
        {
            var lUser = _userDal.Get(p=>p.UserName==userName && p.Password==password);
            if (lUser!=null)
            {
                return lUser;
            }
            return null;
        }
    }
}
