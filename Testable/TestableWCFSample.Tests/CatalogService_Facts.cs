using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Moq;
using System.Collections;
using TestableWCFSample.WebClient.Controllers;
using System.Web.Mvc;
using TestableWCFSample.WebClient.ViewModels;

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
            ICatalogServiceClientFactory catalogServiceClientFactory = null;
            CatalogController controller = new CatalogController(catalogServiceClientFactory);
        }   

        [Fact]
        public void can_call_Products()
        {
            Mock<ICatalogServiceClient> clientMock = new Mock<ICatalogServiceClient>();
            Mock<ICatalogServiceClientFactory> clientFactoryMock = new Mock<ICatalogServiceClientFactory>();
            clientFactoryMock.Setup(factory => factory.BuildCatalogServiceClient()).Returns(clientMock.Object);

            CatalogController controller = new CatalogController(clientFactoryMock.Object);

            var result = controller.Products(3);

            Assert.NotNull(result);
        }

        [Fact]
        public void calling_Products_will_render_a_view()
        {
            // Arrange
            Mock<ICatalogServiceClient> clientMock = new Mock<ICatalogServiceClient>();
            clientMock.Setup(catalogService => catalogService.GetProducts(It.IsAny<int>())).Returns(new string[] {"mal", "wash", "zoe" });
            Mock<ICatalogServiceClientFactory> clientFactoryMock = new Mock<ICatalogServiceClientFactory>();
            clientFactoryMock.Setup(factory => factory.BuildCatalogServiceClient()).Returns(clientMock.Object);

            CatalogController controller = new CatalogController(clientFactoryMock.Object);

            // Act
            ActionResult result = controller.Products(3);

            // Assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            Assert.NotNull(viewResult);

            var model = Assert.IsType<ProductsForCategoryViewModel>(viewResult.ViewData.Model);
            Assert.Equal("Category #3", model.CategoryName);
            Assert.Equal(3, model.Products.Count);
            Assert.Equal("mal", model.Products[0]);
            Assert.Equal("wash", model.Products[1]);
            Assert.Equal("zoe", model.Products[2]);
        }
    }
}
