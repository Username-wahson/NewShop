using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewShop.Entity;
using NewShop.IService;
using NewShop.Common;

namespace NewShop.Service
{
    public class ManagerService : RepositoryBase<ManagerInfo>, IManagerService
    {
        public ManagerInfo Login(string username, string password)
        {
            var entity = this.Get(a=>a.UserName==username);
            if (entity != null)
            {
                string encryptedWithSaltPassword = GetPasswrodWithTwiceEncode(password, entity.PasswordSalt);
                if (encryptedWithSaltPassword.ToLower() != entity.Password)//比较密码是否一致
                    entity = null;//不一致，则置空，表示未找到指定的管理员
                else//一致，则表示登录成功，更新登录时间
                {
                    entity.LoginDate = DateTime.Now;
                    return entity;
                }
            }
            return entity;
        }


        string GetPasswrodWithTwiceEncode(string password, string salt)
        {
            string encryptedPassword = Common.Helper.SecureHelper.MD5(password);//一次MD5加密
            string encryptedWithSaltPassword = Common.Helper.SecureHelper.MD5(encryptedPassword + salt);//一次结果加盐后二次加密
            return encryptedWithSaltPassword;
        }

        /// <summary>
        /// 获取所有管理员
        /// </summary>
        /// <returns></returns>
        public List<ManagerInfo> GetManagers()
        {
            var managers = this.LoadListAll(m=>m.DeleteMark==false);
            return managers;
        }
    }
}
