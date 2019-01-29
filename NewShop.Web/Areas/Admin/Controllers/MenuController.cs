using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewShop.IService;
using NewShop.Model.ViewModel;
using NewShop.Entity;

namespace NewShop.Web.Areas.Admin.Controllers
{
    public class MenuController : Controller
    {

        private IMenuService _iMenuService;

        public MenuController(IMenuService iMenuService)
        {
            _iMenuService = iMenuService; 
        }
        // GET: Admin/Menu
        public ActionResult Index()
        {
            //两种下拉数据绑定
            //List<SelectListItem> selectList = _iMenuService.GetFirstMenu().ToList().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.FullName }).ToList();
            //var menuList = _iMenuService.GetFirstMenu();
            //List<SelectListItem> selectList = new SelectList(menuList, "Id", "FullName").ToList();
            //selectList.Insert(0, new SelectListItem() { Text = "所有分类", Value = "0" });

            var firstMenus = _iMenuService.LoadAll(a => a.DeleteMark == false).Where(a => a.Layers == 1).OrderBy(c => c.SortCode);
            var childMenus = _iMenuService.LoadAll(a => a.DeleteMark == false).Where(a => a.Layers == 2).ToList();
            List<MenuViewModel> list = new List<MenuViewModel>();
            foreach (var item in firstMenus)
            {
                list.Add(new MenuViewModel(item));
                var Menus = childMenus.Where(c => c.ParentId == item.Id).OrderBy(c => c.SortCode);
                if (Menus.Count() == 0)
                    continue;
                foreach (var model in Menus)
                {
                    list.Add(new MenuViewModel(model));
                }
            }
            return View(list);
        }

        public ActionResult Add(long? id)
        {

            MenuViewModel menuViewModel;
            if (id.HasValue)
            {
                var article = _iMenuService.GetMenu(id.Value);
                menuViewModel = new MenuViewModel()
                {

                };
            }
            else
                menuViewModel = new MenuViewModel() { };

            List<SelectListItem> selectList = _iMenuService.GetFirstMenu().ToList().Select(m => new SelectListItem() { Value = m.Id.ToString(), Text = m.FullName }).ToList();
            selectList.Insert(0, new SelectListItem() { Text = "顶级菜单", Value = "0" });
            ViewData["firstmenus"] = selectList;
            return View(menuViewModel);
        }

        [HttpPost]
        public JsonResult Add(MenuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false });
            }
            if (model.ParentId == 0)
            {
                model.Layers = 1;
            }
            else
            {
                model.Layers = 2;
            }
            MenuInfo menu = new MenuInfo()
            {
                Id=model.Id,
                ParentId=model.ParentId,
                FullName=model.FullName,
                UrlAddress=model.UrlAddress,
                SortCode=model.SortCode,
                Layers=model.Layers,
                DeleteMark=false
            };
            if (model.Id > 0)
                _iMenuService.UpdateMenu(menu);
            else
                _iMenuService.AddMenu(menu);
            return Json(new { success = true });
        }




        public JsonResult GetMenu(long id)
        {
            var model = _iMenuService.GetMenu(id);
            return Json(model);
        }
        public JsonResult GetMenus(long parentId)
        {
            var models = _iMenuService.GetFirstMenu();
            return Json(models);
        }

        /// <summary>
        /// 管理页面更改菜单名
        /// </summary>
        public JsonResult UpdateName(string name, long id)
        {
            Tuple<bool, string> result = _iMenuService.UpdateMenuName(id, name);
            if (result.Item1)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }
        /// <summary>
        /// 管理页面更改排序
        /// </summary>
        /// <param name="order"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult UpdateOrder(int sort, long id)
        {
            Tuple<bool, string> result = _iMenuService.UpdateMenuSort(id, sort);
            if (result.Item1)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }
        /// <summary>
        /// 管理页面修改链接
        /// </summary>
        /// <param name="commis"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult UpdateLink(string link, long id)
        {
            Tuple<bool, string> result = _iMenuService.UpdateMenuLink(id, link);
            if (result.Item1)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }

        [HttpPost]
        public JsonResult Delete(long id)
        {
            Tuple<bool, string> result=_iMenuService.DeleteMenu(id);
            if (result.Item1)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }
    }
}