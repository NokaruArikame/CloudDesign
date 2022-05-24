using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServerEntityDataWCF.Model;
using ServerWCF.Service;

namespace ServerWCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "CloudService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы CloudService.svc или CloudService.svc.cs в обозревателе решений и начните отладку.
    public class CloudService : ICloudService
    {
        public string Hello()
        {
            return "Hello";
        }
        
        ArchiveFolderService archiveFolderService = new ArchiveFolderService();
        UserService userService = new UserService();
        
        #region ArchiveFolderService

        public void AddFolder(string name, int parentFolderId)
        {
            archiveFolderService.AddFolder(name, parentFolderId);
        }

        public string GetFolders(int parentId)
        {
            return archiveFolderService.GetFolders(parentId);
        }

        public string GetFoldersJson(int parentId)
        {
            string foldersJson = archiveFolderService.GetFoldersJson(parentId);
            return foldersJson;
        }

        public string GetCloudJson(int userId)
        {
            string cloudJson = archiveFolderService.GetCloudJson(userId);
            return cloudJson;
        }

        public string[] GetData(int userId)
        {
            string[] data = archiveFolderService.GetData(userId);
            if(data == null)
                throw new Exception(nameof(data));
            return data;
        }

        #endregion

        #region UserService
        public void AddUser(string name, string pass) => userService.AddUser(name, pass);

        public bool LoginUser(string userName, string password) => userService.LoginUser(userName, password);

        public bool LogoutUser(int userId) => userService.LogoutUser(userId);

        public bool ChangePasswordUser(string oldPassword, string newPassword)=>userService.ChangePasswordUser(oldPassword, newPassword);

        public string GetUser(string name)
        {
            System.Diagnostics.Debug.WriteLine("Got " + name);
            return userService.GetUser(name);
        }

        public bool RemoveUser(string name) => userService.RemoveUser(name);

        public string GetAuthInfo() => userService.GetAuthInfo();

        #endregion

    }
}
