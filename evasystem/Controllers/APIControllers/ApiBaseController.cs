using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using evasystem.BAL;
using evasystem.Models;
using evasystem.Models.ViewModels;
using Newtonsoft.Json;

namespace evasystem.Controllers
{
    public class ApiBaseController : ApiController
    {
        public LogService oLogService = new LogService();
        public ApiBaseController()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
        public object GetSession(string key)
        {
            return System.Web.HttpContext.Current.Session[key];
        }
    }
}