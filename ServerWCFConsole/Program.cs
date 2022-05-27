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
                        /*foreach(ServiceEndpointElement endpoint in element.Endpoints)
                        {
                            Console.WriteLine();
                            Console.WriteLine("host: "+host.BaseAddresses.First().ToString()+"\nEndpoint: "+endpoint.Address);
                            if (endpoint.Binding.ToString() == "mexHttpsBinding")
                                continue;
                            if (endpoint.Address.ToString() == "")
                                continue;
                            ServiceEndpoint serviceEndpoint = EndpointService.GetEndpointFromElement(   endpoint,
                                                                                                        bindingsSection);
                            EndpointAddress endpointAddress = new EndpointAddress(  host.BaseAddresses.First().ToString() + 
                                                                                    endpoint.Address.ToString());
                            serviceEndpoint.Address = endpointAddress;
                            host.AddServiceEndpoint(serviceEndpoint);
                            Console.WriteLine("Endpoint "+ serviceEndpoint.Name+" added.");
                            //host.AddServiceEndpoint(endpoint.Contract.ToString(),endpoint.Binding.ToString(),endpoint.Address.ToString());
                        }*/
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
            /*using (ServiceHost host = new ServiceHost(typeof(CloudService)))
            {
                var endpoints = host.Extensions.FindAll<EndpointAddress>().ToArray();
                if (endpoints.Length == 0)
                    Console.WriteLine("No endpoints");
                foreach (EndpointAddress endpoint in endpoints)
                    Console.WriteLine(endpoint.ToString());
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
                catch (TimeoutException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }*/
        }
    }
}
