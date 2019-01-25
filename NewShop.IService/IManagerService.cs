using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewShop.Entity;

namespace NewShop.IService
{
    public interface IManagerService:IRepository<ManagerInfo>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码（明文）</param>
        /// <returns></returns>
        ManagerInfo Login(string username, string password);

        List<ManagerInfo> GetManagers();
    }
}
