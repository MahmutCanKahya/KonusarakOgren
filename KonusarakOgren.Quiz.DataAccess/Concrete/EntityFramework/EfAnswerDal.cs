using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.Quiz.DataAccess.Abstract;
using KonusarakOgren.Quiz.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.DataAccess.Concrete.EntityFramework
{
    public class EfAnswerDal : EfEntityRepositoryBase<Answer, QuizDbContext>, IAnswerDal
    {
    }
}
