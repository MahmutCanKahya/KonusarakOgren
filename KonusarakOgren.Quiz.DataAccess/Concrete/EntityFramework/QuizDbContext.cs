using KonusarakOgren.Quiz.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KonusarakOgren.Quiz.DataAccess.Concrete.EntityFramework
{
    public class QuizDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString= "Data Source=quiz.db";
            optionsBuilder.UseSqlite(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>()
                .HasMany(p=>p.Questions)
                .WithOne(b=>b.Exam)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Question>()
                .HasOne(p => p.Exam)
                .WithMany(b => b.Questions)
                .HasForeignKey("ExamId")
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Answer>()
                .HasOne(p => p.Question)
                .WithMany(b => b.Answers)
                .HasForeignKey("QuestionId")
                .OnDelete(DeleteBehavior.SetNull);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> User { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
