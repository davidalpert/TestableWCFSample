using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.NinjectAdapter;
using Ninject;

namespace TestableWCFSample.WebClient
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // this allows us to avoid loading the favicon.icoController w/o 
            // customizing our simple CommonServiceLocatorControllerBuilder.
            routes.IgnoreRoute("favicon.ico"); 

            routes.MapRoute(
                "ProductsByCategory",
                "products/{categoryId}",
                new { controller = "Catalog", action = "Products", categoryId = "" }
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new CommonServiceLocatorControllerFactory());

            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<ICatalogServiceClientFactory>().To<CatalogServiceClientFactory>();

            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(kernel));
        }
    }
}
