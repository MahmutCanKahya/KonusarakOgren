using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.DataAccess.Abstract
{
    public interface IExamDal : IEntityRepository<Exam>
    {
    }
}
