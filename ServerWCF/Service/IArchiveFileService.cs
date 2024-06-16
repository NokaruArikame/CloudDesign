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
        bool AddArchiveFiles(string filesJson);

        [OperationContract]
        bool DeleteArchiveFiles(string filesId);

        [OperationContract]
        string GetArchiveFiles(string userId);
    }
}