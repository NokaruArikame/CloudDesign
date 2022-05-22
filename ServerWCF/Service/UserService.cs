using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServerEntityDataWCF.Repositores;
using ServerEntityDataWCF.Model;

namespace ServerWCF.Service
{
    public class UserService : IUserService
    {
        public void AddUser(string name, string pass)
        {
            UserRepository.AddUser(name, pass);
        }

        public string GetUser(string name)
        {
            User user = UserRepository.GetUser(name);
            if (user == null)
                return null;
            return "Id:"+user.Id + " Name:" + user.Name + " Folder:" + user.UserCloud.Name+"Folder Id:" + user.UserCloud.Id;
        }

        public void RemoveUser(string name)
        {
            UserRepository.RemoveUser(name);
        }
    }
}