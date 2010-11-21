using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UntestableWCFSample.Services
{
    // NOTE: If you change the class name "ICatalogService" here, you must also update the reference to "ICatalogService" in Web.config and in the associated .svc file.
    public class CatalogService : ICatalogService
    {
        public IList<string> GetProducts(int categoryID)
        {
            IList<string> products = BuildFakeProducts(categoryID);

            return products;
        }

        private IList<string> BuildFakeProducts(int categoryID)
        {
            List<string> products = new List<string>();

            int numberOfFakeProducts = 10 + categoryID;
            for (int i = 1; i <= numberOfFakeProducts; i++)
            {
                string fakeProductName = String.Format("Fake Product #{0}-{1}", categoryID, i);
                products.Add(fakeProductName);
            }

            return products;
        }
    }
}
