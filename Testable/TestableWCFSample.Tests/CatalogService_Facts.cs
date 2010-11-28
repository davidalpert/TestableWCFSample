using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Moq;
using System.Collections;
using TestableWCFSample.WebClient.Controllers;

namespace TestableWCFSample.Tests
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
            ICatalogService serviceClient = null;
            CatalogController controller = new CatalogController(serviceClient);
        }

        [Fact]
        public void can_call_Products()
        {
            Mock<CatalogServiceClient> mock = new Mock<CatalogServiceClient>();

            CatalogController controller = new CatalogController(mock.Object);

            var result = controller.Products(3);

            Assert.NotNull(result);
        }
    }
}
