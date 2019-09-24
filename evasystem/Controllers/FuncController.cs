using evasystem.Attributes;
using evasystem.Models.ViewModels;
using evasystem.Models.WebRequest;
using evasystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evasystem.Controllers
{
    public class FuncController : BaseController
    {
        // GET: Func
        [CheckLogin]
        public ActionResult Keyin()
        {
            return View();
        }

        [CheckLogin]
        public ActionResult KeyinList()
        {
            return View();
        }

        FuncService oFuncService = new FuncService();

        [HttpPost]
        public object KeyinSave(KeyinData data)
        {
            ApiResponse response = new ApiResponse();
            myDelegate = () =>
            {
                response.Result = oFuncService.KeyinSave(data, this.GetSession("accountid").ToString());
            };
            return ExecService(myDelegate, response);
        }
    }
}