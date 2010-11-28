using System;
using System.Collections.Generic;

namespace TestableWCFSample.WebClient.ViewModels
{
    public class ProductsForCategoryViewModel
    {
        public string CategoryName { get; set; }
        public IList<string> Products { get; set; }
    }
}
