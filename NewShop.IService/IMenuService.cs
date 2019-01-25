using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewShop.Entity;

namespace NewShop.IService
{
    public interface IMenuService:IRepository<MenuInfo>
    {
        /// <summary>
        /// 获取一个菜单
        /// </summary>
        /// <param name="id">根据id获取</param>
        /// <returns></returns>
        MenuInfo GetMenu(long id);

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu">待添加菜单模型</param>
        void AddMenu(MenuInfo menu);

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="article">待更新的菜单模型</param>
        void UpdateMenu(MenuInfo menu);

        /// <summary>
        /// 获取所有一级菜单
        /// </summary>
        /// <returns></returns>
        List<MenuInfo> GetFirstMenu();
        /// <summary>
        /// 根据一级菜单ID获取二级菜单
        /// </summary>
        /// <returns></returns>
        List<MenuInfo> GetMenuByFirstMenu(long id);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="ids"></param>
        Tuple<bool, string> DeleteMenu(long id);
        /// <summary>
        /// 修改菜单名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Tuple<bool, string> UpdateMenuName(long id,string name);
        /// <summary>
        /// 修改菜单排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Sort"></param>
        /// <returns></returns>
        Tuple<bool, string> UpdateMenuSort(long id, int Sort);
        /// <summary>
        /// 修改菜单链接
        /// </summary>
        /// <param name="id"></param>
        /// <param name="link"></param>
        /// <returns></returns>
        Tuple<bool, string> UpdateMenuLink(long id, string link);
    }
}
