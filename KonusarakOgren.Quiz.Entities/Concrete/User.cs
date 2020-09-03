using KonusarakOgren.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.Entities.Concrete
{
    public class User:IEntity
    {
        public int id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleType { get; set; }
    }
}
