using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using evasystem.BAL;

namespace evasystem.Attributes
{
    public class RequestLogAttribute : ActionFilterAttribute
    {
        private LogService oLogService = new LogService();
        private DateTime startTime;
        private DateTime endTime;
        private string actionName = "";
        private Dictionary<string, object> ActionArguments = new Dictionary<string, object>();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            startTime = DateTime.Now;
            actionName = actionContext.ActionDescriptor.ActionName;
            ActionArguments = actionContext.ActionArguments;
            base.OnActionExecuting(actionContext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            endTime = DateTime.Now;
            var memStream = actionExecutedContext.Response.Content.ReadAsStreamAsync()?.Result;
            string responseBodyString = new StreamReader(memStream).ReadToEnd();
            string Msg = $"ProceesTime : {((endTime - startTime).TotalSeconds).ToString()} Sec";
            //TODO write log
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}