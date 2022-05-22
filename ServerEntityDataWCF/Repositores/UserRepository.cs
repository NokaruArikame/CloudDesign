using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerEntityDataWCF.Model;

namespace ServerEntityDataWCF.Repositores
{
    public class UserRepository
    {
        public static void AddUser(string name, string pass)
        {
            using (ModelContext context = new ModelContext())
            {
                
                User user = new User()
                {
                    Name = name,
                    Password = pass
                }; 
                context.Users.Add(user);
                context.SaveChanges();
                UserCloud folder = new UserCloud() { Name = $"{name}Cloud", User=user };
                context.UsersClouds.Add(folder);
                context.SaveChanges();
            }
        }
        public static User GetUser(string name)
        {
            using(ModelContext context = new ModelContext())
            {
                context.Users.Include(u => u.UserCloud).Load();
                return context.Users.FirstOrDefault(x => x.Name == name);
            }
        }

        public static void RemoveUser(string name)
        {
            using(ModelContext context = new ModelContext())
            {
                User user = context.Users.FirstOrDefault(x => x.Name == name);
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
