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

        [CheckLogin]
        public ActionResult KeyinEdit(int KeyinId)
        {
            ViewBag.KeyinId = KeyinId;
            return View();
        }

        [CheckLogin]
        public ActionResult CompleteList()
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

        [HttpPost]
        public object GetKeyinListData()
        {
            ApiResponse response = new ApiResponse();
            myDelegate = () =>
            {
                response.Result = oFuncService.GetKeyinListData(this.GetSession("accountid").ToString());
            };
            return ExecService(myDelegate, response);
        }

        [HttpPost]
        public object GetKeyinData(string KeyinId)
        {
            ApiResponse response = new ApiResponse();
            myDelegate = () =>
            {
                response.Result = oFuncService.GetKeyinData(KeyinId, this.GetSession("accountid").ToString());
            };
            return ExecService(myDelegate, response);
        }

        [HttpPost]
        public object KeyinEditSave(KeyinUpdateData data)
        {
            ApiResponse response = new ApiResponse();
            myDelegate = () =>
            {
                response.Result = oFuncService.KeyinEditSave(data, this.GetSession("accountid").ToString());
            };
            return ExecService(myDelegate, response);
        }

        [HttpPost]
        public object GetCompleteListData()
        {
            ApiResponse response = new ApiResponse();
            myDelegate = () =>
            {
                response.Result = oFuncService.GetCompleteListData(this.GetSession("accountid").ToString());
            };
            return ExecService(myDelegate, response);
        }
    }
}