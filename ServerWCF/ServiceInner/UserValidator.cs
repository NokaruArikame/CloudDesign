using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;
using ServerEntityDataWCF.Repositores;

namespace ServerWCF.ServiceInner
{
    public class UserValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            System.Diagnostics.Debug.WriteLine(userName + " tried to auth");
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            if (!EntityUserRepository.GetToValidate(userName,password))
            {
                // This throws an informative fault to the client.
                throw new FaultException("Unknown Username or Incorrect Password");
                // When you do not want to throw an infomative fault to the client,
                // throw the following exception.
                // throw new SecurityTokenException("Unknown Username or Incorrect Password");
            }
            System.Diagnostics.Debug.WriteLine(userName + " authed");
        }
    }
}