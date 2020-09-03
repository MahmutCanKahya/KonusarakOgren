using KonusarakOgren.Quiz.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.DataAccess.Concrete.EntityFramework
{
    public class QuizContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString= "Data Source=quiz.db";
            optionsBuilder.UseSqlite(connectionString);
        }
        public DbSet<User> User { get; set; }
    }
}
