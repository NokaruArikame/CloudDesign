using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerEntityDataWCF.Model;

namespace ServerEntityDataWCF.Repositores
{
    public class EntityUserRepository
    {
        public static void AddUser(string name, string pass)
        {
            using (ModelContext context = new ModelContext())
            {
                
                User user = new User()
                {
                    Name = name
                };
                context.Users.Add(user);
                context.Entry(user).Property("Password").CurrentValue = pass;
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

        public static bool GetToValidate(string name, string password)
        {
            System.Diagnostics.Debug.WriteLine(name+" checking database");
            using(ModelContext context =new ModelContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Name == name);
                if (user == null)
                    throw new KeyNotFoundException(name);
                System.Diagnostics.Debug.WriteLine(name + " exists.");
                if (user.Name == name && context.Entry(user).Property("Password").CurrentValue == password)
                {
                    System.Diagnostics.Debug.WriteLine(name + " is ok.");
                    return true;
                }
                return false;
            }
        }
    }
}
