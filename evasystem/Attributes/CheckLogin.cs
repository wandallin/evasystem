using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evasystem.Attributes
{
    public class CheckLogin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if ((this.GetSession("accountid") == null))
            {
                actionContext.Result = new RedirectResult("http://35.206.234.99/");
            }
        }
        public object GetSession(string key)
        {
            return System.Web.HttpContext.Current.Session[key];
        }
    }
}