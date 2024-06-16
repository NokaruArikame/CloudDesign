using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.ServiceModel;
using ServerWCF.Service;

namespace ServerWCFConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(HostService host = new HostService())
            {

            }
        }
    }
}
