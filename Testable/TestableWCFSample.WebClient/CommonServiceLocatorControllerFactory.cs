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
    public class CommonServiceLocatorControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return base.GetControllerInstance(requestContext, controllerType);

            return ServiceLocator.Current.GetInstance(controllerType) as IController;
        }
    }
}
