using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Web;
using System.ServiceModel;
using ServerWCF.Service;
using System.ServiceModel.Description;
using ServerWCF;
using System.Configuration;
using System.ServiceModel.Configuration;
using ServerWCFConsole.Service;

namespace ServerWCFConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ServiceHost> hosts = new List<ServiceHost>();
            try
            {
                var servicesSection = ConfigurationManager.GetSection("system.serviceModel/services") as ServicesSection;
                var bindingsSection = ConfigurationManager.GetSection("system.serviceModel/bindings") as BindingsSection;
                var behaviorsSection = ConfigurationManager.GetSection("system.serviceModel/behaviors") as BehaviorsSection; ;
                if(servicesSection != null)
                {
                    foreach(ServiceElement element in servicesSection.Services)
                    {
                        var serviceType = Type.GetType(element.Name+",ServerWCF");
                        var host = new ServiceHost(serviceType);
                        Console.WriteLine("Host address: " + host.BaseAddresses.First().ToString());
                        
                        foreach (ServiceEndpoint serviceEndpoint in host.Description.Endpoints)
                        {
                            Console.WriteLine("Endpoint name: " + serviceEndpoint.Name + "\nEndpoint Address: " + serviceEndpoint.Address);
                        }
                        hosts.Add(host);
                        host.Open();
                        Console.WriteLine("Host: "+host.ToString()+" opened.");
                    }
                }
            }
            catch(Exception ex)
            { Console.WriteLine(ex.ToString()); }
            finally
            {
                Console.ReadLine();
                foreach(ServiceHost host in hosts)
                {
                    if(host.State==CommunicationState.Opened)
                    {
                        host.Close();
                    }
                    else
                    {
                        host.Abort();
                    }
                }
            }
        }
    }
}
