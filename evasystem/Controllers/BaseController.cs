using evasystem.Models;
using evasystem.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace evasystem.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult ReturnJsonContent(object vm)
        {
            return Content(JsonConvert.SerializeObject(vm), "application/json");
        }

        public delegate void ResponseDelegate();
        public ResponseDelegate myDelegate;
        public ActionResult ExecService(ResponseDelegate serviceDelegate, ApiResponse response)
        {
            try
            {
                serviceDelegate(); //執行服務
            }
            catch (ValidationErrors errors)
            {
                response.ErrorSetting();
                foreach (var error in errors.Errors)
                {
                    response.Message += error.PropertyExceptionMessage + "\r\n";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null) ex = ex.InnerException;
                response.ErrorSetting(ex.Message);
                //oLogService.InsertLog(Log_Type.Error, serviceDelegate.GetMethodInfo().Name, "", "", ex.Message, this.AccountId.ToString());
            }
            return ReturnJsonContent(response);
        }
        public ActionResult ExecService<T>(ResponseDelegate serviceDelegate, T response)
        {
            try
            {
                serviceDelegate(); //執行服務
            }
            catch (Exception)
            {

            }
            return ReturnJsonContent(response);
        }
        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if ((this.GetSession("account") == null))
            {
                //沒登入

            }
            else
            {
                //已登入
            }
            return base.BeginExecute(requestContext, callback, state);
        }
        public object GetSession(string key)
        {
            return System.Web.HttpContext.Current.Session[key];
        }
    }
}