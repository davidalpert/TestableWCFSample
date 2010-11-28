using System;
using System.Web.Mvc;

namespace TestableWCFSample.WebClient.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
