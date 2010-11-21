using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UntestableWCFSample.Services
{
    // NOTE: If you change the interface name "ICatalogService" here, you must also update the reference to "IService1" in Web.config.
    [ServiceContract]
    public interface ICatalogService
    {
        [OperationContract]
        IList<string> GetProducts(int categoryID);
    }
}
