using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UntestableWCFSample.WebClient.ViewModels;

namespace UntestableWCFSample.WebClient.Controllers
{
    [HandleError]
    public class CatalogController : Controller
    {
        public ActionResult Products(int? categoryID)
        {
            categoryID = categoryID ?? 1;

            ProductsForCategoryViewModel model = new ProductsForCategoryViewModel
            {
                CategoryName = String.Format("Category #{0}", categoryID.Value),
                Products = new List<string>()
            };

            return View(model);
        }
    }
}