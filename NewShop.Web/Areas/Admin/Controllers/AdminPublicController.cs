using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewShop.Web.Areas.Admin.Controllers
{
    public class AdminPublicController : Controller
    {
        // GET: Admin/AdminPublic
        public ActionResult Top()
        {
            return View();
        }


        public ActionResult Bottom()
        {
            return View();
        }
    }
}