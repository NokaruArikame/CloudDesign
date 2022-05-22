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
        void AddUser(string name, string pass);
        [OperationContract]
        void RemoveUser(string name);
    }
}