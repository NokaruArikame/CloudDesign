using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ServerEntityDataWCF.Model;

namespace ServerWCF.Service
{
    [ServiceContract]
    public interface IArchiveFolderService
    {
        [OperationContract]
        void AddFolder(string name, int parentFolderId);

        [OperationContract]
        string GetFolders(int parentFolderId);
        [OperationContract]
        string GetFoldersJson(int parentFolderId);

        [OperationContract]
        string GetCloudJson(int userId);

        [OperationContract]
        string[] GetData(int userId);

        

    }
}
