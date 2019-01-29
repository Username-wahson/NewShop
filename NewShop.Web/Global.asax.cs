using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NewShop.Common.IOC;

namespace NewShop.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //网站第一次启动执行
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();//注册区域
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);//注册路由
            BundleConfig.RegisterBundles(BundleTable.Bundles);//捆绑

            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory());//注入Controller
        }
    }
}
