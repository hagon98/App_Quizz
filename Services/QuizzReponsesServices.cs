using App_Quizz.Models;
using Microsoft.EntityFrameworkCore;

namespace App_Quizz.Services
{
    public class QuizzReponsesServices : IQuizzReponsesServices
    {
        private readonly MyContext db;

        public QuizzReponsesServices(MyContext db)
        {
            this.db = db;
        }

        public async Task Save(QuizzReponses reponses)
        {
            db.quizzReponses.Add(reponses);
            await db.SaveChangesAsync();
        }

        public async Task Update(QuizzReponses reponses)
        {
            db.quizzReponses.Attach(reponses);
            db.Entry(reponses).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
