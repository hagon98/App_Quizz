using App_Quizz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App_Quizz.Services
{
    public class QuizzServices : IQuizzServices
    {
        private readonly MyContext db;

        public QuizzServices(MyContext db)
        {
            this.db = db;
        }

        public int CountQuestions(int quizId)
        {
            return db.quizzQuestions.AsNoTracking().Where(quest => quest.QuizzId == quizId).Count(); 
        }

        public async Task<QuizzQuestions> FindQuestion(int quizId, int numOrder)
        {
            return await db.quizzQuestions.AsNoTracking().SingleOrDefaultAsync(quest => quest.QuizzId == quizId && quest.NumOrder == numOrder);
        }

        public async Task<Quizz> FindQuizById(int quizId)
        {
            return await db.quizzs.FindAsync(quizId);
        }

        public async Task<List<Quizz>> FindQuizzes()
        {
            return  await db.quizzs.Include(quizz => quizz.Category).AsNoTracking().ToListAsync();
        }

        public async Task<QuizzReponses> FindResponseById(int responseId)
        {
            return await db.quizzReponses.FindAsync(responseId);
        }

        public async Task<List<QuizzReponses>> FindResponses(int questionId)
        {
            return await db.quizzReponses.AsNoTracking().Where(r => r.QuizzQuestionsId == questionId).ToListAsync();
        }

        public async Task Save(Quizz q)
        {
            db.quizzs.Add(q);
            await db.SaveChangesAsync();
            

        }

        public async Task Update(Quizz q)
        {
            db.quizzs.Attach(q);
            db.Entry(q).State = EntityState.Modified;
           await db.SaveChangesAsync();
        }
    }
}
