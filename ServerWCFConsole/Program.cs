using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerWCF.Service;
using System.ServiceModel;
using ServerWCF;
using System.Configuration;
using System.ServiceModel.Web;

namespace ServerWCFConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            using( ServiceHost = new ServiceHost(typeof(CloudService)))
            {
                string terminate;
                try
                {
                    host.Open();
                    Console.WriteLine("The service is ready.");
                    Console.WriteLine("Input exit to terminate service.");
                    do
                    {
                        terminate = Console.ReadLine();
                    }
                    while (terminate != "exit");
                }
                catch(TimeoutException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
