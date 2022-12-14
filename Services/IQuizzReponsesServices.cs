using App_Quizz.Models;

namespace App_Quizz.Services
{
    public interface IQuizzReponsesServices
    {
        Task Save(QuizzReponses reponses);

        Task Update(QuizzReponses reponses);
    }
}
