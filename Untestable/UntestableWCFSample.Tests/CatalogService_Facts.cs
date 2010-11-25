using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Collections;
using UntestableWCFSample.WebClient.Controllers;

namespace UntestableWCFSample.Tests
{
    public class CatalogService_Facts
    {
        [Fact(Skip="Cannot create a service client this easily w/o importing config entries from the web project's web.config.")]
        public void can_create()
        {
            CatalogServiceClient serviceClient = new CatalogServiceClient();
        }
    }

    public class CatalogController_Facts
    {
        [Fact]
        public void can_create()
        {
            CatalogController controller = new CatalogController();
        }

        [Fact]
        public void can_call_Products()
        {
            CatalogController controller = new CatalogController();

            var result = controller.Products(3);

            Assert.NotNull(result);
        }
    }
}
