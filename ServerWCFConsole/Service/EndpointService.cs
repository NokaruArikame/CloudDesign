using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;

namespace ServerWCFConsole.Service
{
    internal static class EndpointService
    {
        public static ServiceEndpoint GetEndpointFromElement(   ServiceEndpointElement endpointElement,
                                                                BindingsSection bindings)
        {
            ContractDescription contractDescription = new ContractDescription(endpointElement.Contract);
            ServiceEndpoint endpoint = new ServiceEndpoint(ContractDescription.GetContract(Type.GetType(endpointElement.Contract+",ServerWCF")));
            endpoint.Name=endpointElement.Name;
            switch (endpointElement.Binding.ToString())
            {
                case "wsHttpBinding":
                    endpoint.Binding = BindingService.GetWSBindingFromBindingSection(bindings,
                                                                                endpointElement.BindingConfiguration.ToString());
                    break;
                case "mexHttpBinding":
                    return null;
                

            }

            Console.WriteLine("Endpoint: "  +
                        "\nBinding: " + endpoint.Binding.ToString() +
                        "\nContract: " + endpoint.Contract.Namespace +
                        "\n");
            return endpoint;
        }
    }
}
