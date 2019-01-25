using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShop.IService
{
    public static class CacheKeyCollection
    {
        /// <summary>
        /// 管理员账号信息缓存键
        /// </summary>
        /// <param name="managerId">管理员id</param>
        /// <returns></returns>
        public static string Manager(long managerId)
        {
            return string.Format("Cache-Manager-{0}", managerId);
        }

        /// <summary>
        /// 登录错误缓存（一般保留15分钟）
        /// </summary>
        /// <param name="username">出错时用户名</param>
        /// <returns></returns>
        public static string ManagerLoginError(string username)
        {
            return string.Format("Cache-Manager-Login-{0}", username);
        }
    }
}
