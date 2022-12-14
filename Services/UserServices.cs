using App_Quizz.Models;
using Microsoft.EntityFrameworkCore;

namespace App_Quizz.Services
{
    public class UserServices: IUserServices
    {
        private readonly MyContext db;

        public UserServices(MyContext db)
        {
            this.db = db;
        }

        public async Task Delete(int id)
        {
            User user = await db.users.FindAsync(id);
            if (user != null)
            {
                db.users.Remove(user);
               await db.SaveChangesAsync();
            }
            else
            {
                throw new Exception("User introuvable");
            }
        }

        public async Task<List<User>> FindAll()
        {
            return await db.users.AsNoTracking().ToListAsync();
        }

        public async Task<User> FindById(int id)
        {
            return await db.users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> FindByName(string name)
        {
            return await db.users.Where(x => x.Name == name).FirstOrDefaultAsync();
        }

        public async Task Save(User u)
        {
            db.users.Add(u);
           await db.SaveChangesAsync();
        }

        public async Task Update(User u)
        {

            db.users.Attach(u);
            db.Entry(u).State = EntityState.Modified;
           await db.SaveChangesAsync();
        }
    }
}
