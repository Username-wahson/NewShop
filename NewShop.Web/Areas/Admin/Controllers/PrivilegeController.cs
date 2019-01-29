using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewShop.Web.Areas.Admin.Controllers
{
    public class PrivilegeController : Controller
    {
        // GET: Admin/Privilege
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            ViewBag.Privileges = null;
            return View();
        }
    }
}