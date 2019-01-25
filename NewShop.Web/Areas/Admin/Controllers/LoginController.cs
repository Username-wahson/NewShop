using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewShop.IService;
using NewShop.Entity;
using NewShop.Common.Helper;

namespace NewShop.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private IManagerService _iManagerService;

        public LoginController(IManagerService iManagerService)
        {
            _iManagerService = iManagerService; // 第三方容器.构造<T>();
        }
        /// <summary>
        /// 同一用户名无需验证的的尝试登录次数
        /// </summary>
        const int TIMES_WITHOUT_CHECKCODE = 3;
        
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        //登录
        [HttpPost]
        public JsonResult Login(string username, string password, string checkCode)
        {
            string msg = "", host = System.Web.HttpContext.Current.Request.Url.Host;
            try
            {
                //检查验证码
                CheckCheckCode(username, checkCode);
                var manager = _iManagerService.Login(username, password);
                if (manager == null)
                {
                    throw new Exception("用户名和密码不匹配");
                }
                ClearErrorTimes(username);//清除输入错误记录次数
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                int errorTimes = SetErrorTimes(username);
                return Json(new { success = false, msg = ex.Message, errorTimes = errorTimes, minTimesWithoutCheckCode = TIMES_WITHOUT_CHECKCODE });
            }

        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        [HttpGet]
        public ActionResult GetCheckCode()
        {
            string code;
            var image = new verify_code().Create(out code);
            Session["checkCode"] = code;
            return File(image.ToArray(), "image/png");
        }
        /// <summary>
        /// 检查验证码
        /// </summary>
        /// <param name="username"></param>
        /// <param name="checkCode"></param>
        void CheckCheckCode(string username, string checkCode)
        {
            var errorTimes = GetErrorTimes(username);
            if (errorTimes >= TIMES_WITHOUT_CHECKCODE)
            {
                if (string.IsNullOrWhiteSpace(checkCode))
                    throw new Exception("30分钟内登录错误3次以上需要提供验证码");

                string systemCheckCode = Session["checkCode"] as string;
                if (systemCheckCode.ToLower() != checkCode.ToLower())
                    throw new Exception("验证码错误");

                //生成随机验证码，强制使验证码过期（一次提交必须更改验证码）
                Session["checkCode"] = Guid.NewGuid().ToString();
            }
        }


        /// <summary>
        /// 获取指定用户名在30分钟内的错误登录次数
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int GetErrorTimes(string username)
        {
            var timesObject = Common.CacheMgr.Cache.Get(CacheKeyCollection.ManagerLoginError(username));
            var times = timesObject == null ? 0 : int.Parse(timesObject.ToString());
            return times;
        }
        /// <summary>
        /// 清除错误次数
        /// </summary>
        /// <param name="username"></param>
        void ClearErrorTimes(string username)
        {
            Common.CacheMgr.Cache.Remove(CacheKeyCollection.ManagerLoginError(username));
        }

        /// <summary>
        /// 设置错误登录次数
        /// </summary>
        /// <param name="username"></param>
        /// <returns>返回最新的错误登录次数</returns>
        int SetErrorTimes(string username)
        {
            var times = GetErrorTimes(username) + 1;
            Common.CacheMgr.Cache.Insert(CacheKeyCollection.ManagerLoginError(username), times, DateTime.Now.AddMinutes(30.0));//写入缓存
            return times;
        }
    }
}