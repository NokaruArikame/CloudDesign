using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using ServerEntityDataWCF.Model;

namespace ServerWCF.Service
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        string GetUser(string name);
        [OperationContract]
        void AddUser(string name, string password);
        [OperationContract]
        bool RemoveUser(string name);
        [OperationContract]
        bool LoginUser(string name, string password);
        [OperationContract]
        bool LogoutUser(int userId);
        [OperationContract]
        bool ChangePasswordUser(string oldPassword, string newPassword);

        [OperationContract]
        string GetAuthInfo();
    }
}