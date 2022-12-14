using App_Quizz.Models;

namespace App_Quizz.Services
{
    public interface IUserServices
    {
        Task Delete(int id);
        Task<List<User>> FindAll();
        Task<User> FindByName(string name);
        Task<User> FindById(int id);
        Task Save(User u);
        Task Update(User u);
        
    }
}
