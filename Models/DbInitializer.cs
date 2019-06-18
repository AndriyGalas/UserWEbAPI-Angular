using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProject.Models
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(AppDbContext appContext)
        {
            AppDbContext appDbContext = appContext;

            if (appDbContext.Users.Count() == 0)
            {
                UserModel[] books = new UserModel[]
                {
                    new UserModel { Name = "Madame Bovary", Email = "MaBo@gmail.com", IsDisabled = false,
                        IsMale = false, MobileNumber = "023882382", Hobbies = "none", Description = "none"},
                    new UserModel { Name = "Second Man", Email = "SeMan@gmail.com", IsDisabled = false,
                        IsMale = false, MobileNumber = "023882382", Hobbies = "none", Description = "none"},
                    new UserModel { Name = "George Eliot", Email = "Geelo@gmail.com", IsDisabled = false,
                        IsMale = false, MobileNumber = "023882382", Hobbies = "none", Description = "none"}
                };

                foreach (var book in books)
                {
                    await appDbContext.Users.AddAsync(book);
                }

                await appDbContext.SaveChangesAsync();
            }
        }
    }
}
