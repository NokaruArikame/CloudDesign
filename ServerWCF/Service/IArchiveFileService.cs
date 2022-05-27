using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace ServerWCF.Service
{
    [ServiceContract]
    public interface IArchiveFileService
    {
        [OperationContract]
        bool AddArchiveFiles(string filesJson); // +

        [OperationContract]
        bool DeleteArchiveFiles(int fileId); // +

        [OperationContract]
        string GetArchiveFiles(int userId); // +

        [OperationContract]
        bool ChangeParentFolder(int newParentId, int fileId); // +
    }
}