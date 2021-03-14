using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSiteBanHangMVC.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Header()
        {
            return View();
        }

        public ActionResult Footer()
        {
            return View();
        }
    }
}