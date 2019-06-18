using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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


        public async Task<ICollection<UserModel>> GetAll()
        {
            var allUsers = await appDbContext.Users.ToListAsync();
            return allUsers;
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
            var userModel = await appDbContext.Users.FindAsync(id);

            userModel.Name = item.Name;
            userModel.Email = item.Email;
            userModel.Description = item.Description;
            userModel.Hobbies = item.Hobbies;
            userModel.IsDisabled = item.IsDisabled;
            userModel.IsMale = item.IsMale;
            userModel.MobileNumber = item.MobileNumber;
            
            await appDbContext.SaveChangesAsync();

        }
    }
}
