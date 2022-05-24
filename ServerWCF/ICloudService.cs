using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ServerWCF.Service;

namespace ServerWCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ICloudService" в коде и файле конфигурации.


    [ServiceContract]
    public interface ICloudService : IUserService
    {
        [OperationContract]
        string Hello();
    }
}
