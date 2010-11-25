using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

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
}
