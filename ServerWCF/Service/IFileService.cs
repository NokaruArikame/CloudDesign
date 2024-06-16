using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerWCF.Service
{
    public interface IFileService
    {
        bool AddFiles();

        bool DeleteFiles();

        void GetFiles();
    }
}