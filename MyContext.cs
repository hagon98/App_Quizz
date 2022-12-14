using App_Quizz.Models;
using Microsoft.EntityFrameworkCore;

namespace App_Quizz
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Quizz> quizzs { get; set; }
        public DbSet<QuizzCategory> quizzCategories { get; set; }
        public DbSet<QuizzQuestions> quizzQuestions { get; set; }
        public DbSet<QuizzReponses> quizzReponses { get; set; }
        public DbSet<QuizzTest> quizTests { get; set; }
        public DbSet<User> users { get; set; }
    }
}
