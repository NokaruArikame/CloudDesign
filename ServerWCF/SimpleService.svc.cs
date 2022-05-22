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
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "SimpleService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы SimpleService.svc или SimpleService.svc.cs в обозревателе решений и начните отладку.
    public class SimpleService : ISimpleService
    {
        ArchiveFolderService archiveFolderService = new ArchiveFolderService();
        UserService userService = new UserService();
        /*public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }*/

        #region FolderService
        /*public void AddFolder(string name, int cloudId)
        {
            archiveFolderService.AddFolder(name, cloudId);
        }*/

        public void AddFolder(string name, int parentFolderId)
        {
            archiveFolderService.AddFolder(name, parentFolderId);
        }

        /*public List<ArchiveFolder> GetChildFolders(int parentId, int cloudId)
        {
            throw new NotImplementedException();
        }*/

        /*public ArchiveFolder GetFirstFolder(int cloudId)
        {
            throw new NotImplementedException();
        }*/

        public string GetFolders(int parentId)
        {
            return archiveFolderService.GetFolders(parentId);
        }

        public string GetFoldersJson(int parentId)
        {
            string foldersJson = archiveFolderService.GetFoldersJson(parentId);
            return foldersJson;
        }

        #endregion

        #region UserService
        public void AddUser(string name, string pass)
        {
            userService.AddUser(name, pass);
        }

        public string GetUser(string name)
        {
            return userService.GetUser(name);
        }

        public void RemoveUser(string name)
        {
            archiveFolderService.RemoveUser(name);
        }



        #endregion

    }
}
