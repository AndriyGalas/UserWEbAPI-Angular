using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserProject.Models.Interfaces;

namespace UserProject.Models.Services
{
    public class UserService 
    {
        private readonly AppDbContext appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public IEnumerable<UserModel> GetAll()
        {
            return appDbContext.Users.ToList();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await appDbContext.Users.FindAsync(id);
        }

        public async Task Add(UserModel item)
        {
            appDbContext.Users.Add(item);
            await appDbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var existing = appDbContext.Users.Find(id);
            if (existing != null)
            {
                appDbContext.Users.Remove(existing);
            }

            await appDbContext.SaveChangesAsync();
        }

        public async Task Update(int id, UserModel item)
        {
            var userModel = appDbContext.Users.Find(id);

            userModel.Name = item.Name;
            userModel.Email = item.Email;
            userModel.Description = item.Description;
            userModel.Hobbies = item.Hobbies;
            userModel.IsDisabled = item.IsDisabled;
            userModel.IsMale = item.IsMale;
            userModel.MobileNumber = item.MobileNumber;

            appDbContext.Users.Update(item);
            await appDbContext.SaveChangesAsync();

        }
    }
}
