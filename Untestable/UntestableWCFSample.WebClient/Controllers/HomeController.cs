﻿using System;
using System.Web.Mvc;

namespace UntestableWCFSample.WebClient.Controllers
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