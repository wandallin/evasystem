using evasystem.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evasystem.Controllers
{
    public class PartialController : BaseController
    {
        public PartialViewResult TopNav()
        {
            ViewBag.accountid = this.GetSession("accountid");
            ViewBag.name = this.GetSession("name");
            return PartialView();
        }

        public PartialViewResult index()
        {
            return PartialView();
        }

        public PartialViewResult Logout()
        {
            HttpContext ctx = System.Web.HttpContext.Current;
            ctx.Session["LoginSuccessFlag"] = null;
            ctx.Session["accountid"] = null;
            ctx.Session["height"] = null;
            ctx.Session["weight"] = null;
            return PartialView();
        }
    }
}