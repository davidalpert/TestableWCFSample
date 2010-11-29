using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TestableWCFSample.WebClient.ViewModels;

namespace TestableWCFSample.WebClient.Controllers
{
    [HandleError]
    public class CatalogController : Controller
    {
        ICatalogServiceClientFactory catalogServiceClientFactory;

        /// <summary>
        /// Initializes a new instance of the CatalogController class.
        /// </summary>
        /// <param name="catalogServiceClientFactory"></param>
        public CatalogController(ICatalogServiceClientFactory catalogServiceClientFactory)
        {
            this.catalogServiceClientFactory = catalogServiceClientFactory;
        }

        public ActionResult Products(int? categoryID)
        {
            categoryID = categoryID ?? 1;

            ProductsForCategoryViewModel model = new ProductsForCategoryViewModel
            {
                CategoryName = String.Format("Category #{0}", categoryID.Value),
                Products = LoadProductsFor(categoryID)
            };

            return View(model);
        }

        private IList<string> LoadProductsFor(int? categoryID)
        {
            ICatalogServiceClient catalogService = catalogServiceClientFactory.BuildCatalogServiceClient();

            IList<string> products = catalogService.GetProducts(categoryID.Value);

            // now we can take responsibility for closing the connection 
            // as per the guidance, but this time via the easily mockable 
            // interface.
            catalogService.Close(); 

            return products;
        }
    }
}
