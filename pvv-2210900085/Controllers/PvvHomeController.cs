using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pvv_2210900085.Controllers
{
    public class PvvHomeController : Controller
    {
        public ActionResult PvvIndex()
        {
            return View();
        }

        public ActionResult PvvAbout()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PvvContact()
        {
            ViewBag.msv  = "2210900085";
            ViewBag.fullname = "phan viết vượng";

            return View();
        }
    }
}