using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSPA.Controllers
{
    public class EarnDateController : Controller
    {
        // GET: EarnDate
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}