using App_Quizz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Execution;

namespace App_Quizz.Services
{
    public interface IQuizzServices
    {
        Task<List<Quizz>> FindQuizzes();
        Task<Quizz> FindQuizById(int quizId);
        Task<QuizzQuestions> FindQuestion(int quizId, int numOrder);
        Task<List<QuizzReponses>> FindResponses(int questionId);
        Task<QuizzReponses> FindResponseById(int responseId);
        int CountQuestions(int quizId);
        Task Save(Quizz q);
        Task Update(Quizz q);
    }
}
