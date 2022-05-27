using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace ServerWCFConsole.Service
{
    internal static class BindingService
    {
        public static WSHttpBinding GetWSBindingFromBindingSection( BindingsSection bindingsSection,
                                                                    string bindingName)
        {
            WSHttpBinding wSHttpBinding = new WSHttpBinding();
            foreach(WSHttpBindingElement bindingElement in bindingsSection.WSHttpBinding.Bindings)
            {
                if(bindingElement.Name == bindingName)
                {
                    bindingElement.ApplyConfiguration(wSHttpBinding);
                    //Console.WriteLine("Binding: "+wSHttpBinding.Name+" Security: "+wSHttpBinding.Security.ToString());
                }
            }
            return wSHttpBinding;
        }


    }
}
