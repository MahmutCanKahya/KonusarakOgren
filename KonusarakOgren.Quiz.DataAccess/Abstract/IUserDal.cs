using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Quiz.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
    }
}
