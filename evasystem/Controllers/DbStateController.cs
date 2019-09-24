using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using evasystem.BAL;

namespace evasystem.Controllers
{
    public class DbStateController : Controller
    {
        LogService oLogService = new LogService();
        public ActionResult Index()
        {
            oLogService.OpDbConnection();

            return View();
        }
        private string GetServerName()
        {
            return System.Web.HttpContext.Current.Server.MachineName;
        }
    }
}