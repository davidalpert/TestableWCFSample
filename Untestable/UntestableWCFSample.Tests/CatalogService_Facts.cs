using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UntestableWCFSample.Tests
{
    public class CatalogService_Facts
    {
        [Fact]
        public void can_create()
        {
            CatalogServiceClient serviceClient = new CatalogServiceClient();
        }
    }
}
