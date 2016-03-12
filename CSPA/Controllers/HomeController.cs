﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CSPA.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/App");
            //return View();
        }

        public ActionResult DashBoard()
        {
            return PartialView();
        }
    }
}
