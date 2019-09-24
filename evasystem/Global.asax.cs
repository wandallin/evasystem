using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace evasystem
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //只回傳JSON格式
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //JSON自動縮排
            var config = new HttpConfiguration();
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
#if DEBUG
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
#else
            // 定義允許的 Domain
            string AllowDomainsStr = "";
            List<string> AllowDomains = new List<string>();
            AllowDomains.Add("https://*.asus.com");
            AllowDomains.Add("http://*.asus.com");
            AllowDomains.Add("https://*.asus.com.cn");
            AllowDomains.Add("http://*.asus.com.cn");
            AllowDomains.Add("https://tongji.baidu.com");
            foreach (string Domain in AllowDomains)
            {
                AllowDomainsStr += Domain + " ";
            }

            // 加上 Content-Security-Policy Header
            HttpContext.Current.Response.AddHeader("Content-Security-Policy", "frame-ancestors " + AllowDomainsStr);

            // 加上 X-Content-Security-Policy
            HttpContext.Current.Response.AddHeader("X-Content-Security-Policy", "frame-ancestors " + AllowDomainsStr);
#endif
        }

        void Application_Error(object sender, EventArgs e)
        {
            //System.Web.HttpContext.Current.Response.Redirect("https://www.asus.com/");
            //TODO
            //導頁 & 寫Log
        }
    }
}
