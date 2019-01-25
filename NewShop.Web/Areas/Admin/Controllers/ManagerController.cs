using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewShop.IService;

namespace NewShop.Web.Areas.Admin.Controllers
{
    public class ManagerController : Controller
    {
        private IManagerService _iManagerService;
        private IPrivilegesService _iPrivilegesService;

        public ManagerController(IManagerService iManagerService, IPrivilegesService iPrivilegesService)
        {
            _iManagerService = iManagerService; // 第三方容器.构造<T>();
            _iPrivilegesService = iPrivilegesService;
        }
        // GET: Admin/Manager
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List(int page, string keywords, int rows, bool? status = null)
        {
            var result = _iManagerService.GetManagers();
            var role = _iPrivilegesService.GetRoles().ToList();
            var managers = result.ToList().Select(item => new
            {
                Id = item.Id,
                UserName = item.UserName,
                CreatorTime = item.CreatorTime.ToString(),
                RoleName = item.RoleId == 0 ? "系统管理员" : role.Where(a => a.Id == item.RoleId).FirstOrDefault().RoleName,
                RoleId = item.RoleId
            });
            var model = new { rows = managers, total = result.Count() };
            return Json(model);
        }
    }
}