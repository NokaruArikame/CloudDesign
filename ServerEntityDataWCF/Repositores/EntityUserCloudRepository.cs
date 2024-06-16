using Microsoft.EntityFrameworkCore;
using ServerEntityDataWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerEntityDataWCF.Repositores
{
    public class EntityUserCloudRepository
    {
        public static UserCloud GetCloud(int userId)
        {
            UserCloud userCloud;
            using (var db = new ModelContext())
            {
                db.UsersClouds.Where(c => c.UserId == userId).Include(u => u.User).Load();
                userCloud = db.UsersClouds.FirstOrDefault(c => c.UserId == userId);
            }
            return userCloud;
        }
    }
}
