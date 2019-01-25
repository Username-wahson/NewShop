using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewShop.Entity;

namespace NewShop.IService
{
    public interface IPrivilegesService : IRepository<RoleInfo>
    {
        /// <summary>
        /// 添加一个平台管理员角色
        /// </summary>
        //void AddRole(RoleInfo model);

        ///// <summary>
        ///// 修改平台管理员角色
        ///// </summary>
        //void UpdateRole(RoleInfo model);

        ///// <summary>
        ///// 删除一个平台角色
        ///// </summary>
        ///// <param name="id"></param>
        //void DeleteRole(long id);

        ///// <summary>
        ///// 获取一个平台角色的详情
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //RoleInfo GetRole(long id);

        /// <summary>
        /// 获取平台角色列表
        /// </summary>
        /// <returns></returns>
        IQueryable<RoleInfo> GetRoles();

    }
}
