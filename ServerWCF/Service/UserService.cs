using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServerEntityDataWCF.Repositores;
using ServerEntityDataWCF.Model;
using System.ServiceModel;

namespace ServerWCF.Service
{
    public class UserService : IUserService
    {
        public void AddUser(string name, string pass)
        {
            EntityUserRepository.AddUser(name, pass);
        }

        public bool ChangePasswordUser(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public string GetUser(string name)
        {
            User user = EntityUserRepository.GetUser(name);
            if (user == null)
                return null;
            return "Id:" + user.Id + " Name:" + user.Name + " Folder:" + user.UserCloud.Name + "Folder Id:" + user.UserCloud.Id;
        }

        public bool LoginUser(string name, string password)
        {
            throw new NotImplementedException();
        }

        public bool LogoutUser(int userId)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(string name)
        {
            EntityUserRepository.RemoveUser(name);
            return true;
        }

        public string GetAuthInfo() { return ServiceSecurityContext.Current.PrimaryIdentity.Name; }
    }
}