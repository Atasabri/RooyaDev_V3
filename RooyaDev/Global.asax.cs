using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Globalization;
using System.Threading;

namespace RooyaDev
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //Thread.CurrentThread.CurrentCulture =
            //CultureInfo.CreateSpecificCulture("ar");
            //Thread.CurrentThread.CurrentUICulture = new
            //    CultureInfo("ar");
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Cookies["Language"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new
                CultureInfo(Request.Cookies["Language"].Value);
                Thread.CurrentThread.CurrentUICulture = new
                    CultureInfo(Request.Cookies["Language"].Value);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture =
                CultureInfo.CreateSpecificCulture("ar");
                Thread.CurrentThread.CurrentUICulture = new
                    CultureInfo("ar");
                HttpCookie cookie = new HttpCookie("Language");
                cookie.Value = "ar";
                Response.Cookies.Add(cookie);
            }
        }
    }
}
