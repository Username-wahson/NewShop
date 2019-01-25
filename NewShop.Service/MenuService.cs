using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NewShop.Common;
using NewShop.Entity;
using NewShop.IService;
using NewShop.Service;

namespace NewShop.Service
{
    class MenuService: RepositoryBase<MenuInfo> ,IMenuService
    {
        public void AddMenu(MenuInfo menu)
        {
            menu.CreatorTime = DateTime.Now;
            this.Save(menu);
        }

        public MenuInfo GetMenu(long id)
        {
            var menu = this.Get(a => a.Id == id);
            return menu;
        }

        public List<MenuInfo> GetFirstMenu()
        {
            var menuList = this.LoadListAll(a => a.ParentId==0 && a.DeleteMark==false);
            return menuList;
        }

        public List<MenuInfo> GetMenuByFirstMenu(long id)
        {
            var menuList = this.LoadListAll(a => a.ParentId==id);
            return menuList;
        }

        public void UpdateMenu(MenuInfo menu)
        {
            menu.LastModifyTime = DateTime.Now;
            this.Update(menu);
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        public Tuple<bool, string> DeleteMenu(long id)
        {
            var model = this.Get(a => a.Id == id);
            model.DeleteMark = true;
            model.DeleteTime = DateTime.Now;
            bool result= this.Update(model);
            if (result)
            {
                return Tuple.Create(true, "操作成功！");
            }
            else
            {
                return Tuple.Create(false, "操作失败！");
            }
        }

        /// <summary>
        /// 修改菜单名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Tuple<bool, string> UpdateMenuName(long id, string name)
        {
            var model = this.Get(a => a.Id == id);
            model.FullName = name;
            bool result = this.Update(model);
            if (result)
            {
                return Tuple.Create(true, "操作成功！");
            }
            else
            {
                return Tuple.Create(false, "操作失败！");
            }
        }

        public Tuple<bool, string> UpdateMenuSort(long id, int Sort)
        {
            var model = this.Get(a => a.Id == id);
            model.SortCode = Sort;
            bool result = this.Update(model);
            if (result)
            {
                return Tuple.Create(true, "操作成功！");
            }
            else
            {
                return Tuple.Create(false, "操作失败！");
            }
        }

        public Tuple<bool, string> UpdateMenuLink(long id, string link)
        {
            var model = this.Get(a => a.Id == id);
            model.UrlAddress = link;
            bool result = this.Update(model);
            if (result)
            {
                return Tuple.Create(true, "操作成功！");
            }
            else
            {
                return Tuple.Create(false, "操作失败！");
            }
        }
    }
}
