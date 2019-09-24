using evasystem.Models.ViewModels;
using evasystem.Models.ViewModels.Account;
using evasystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace evasystem.Controllers
{
    public class HomeController : Controller
    {
        public AccountService oAccountService = new AccountService();

        [HttpPost]
        public bool Login(string username = "", string password = "")
        {
            HttpContext ctx = System.Web.HttpContext.Current;
            bool loginSuccessFlag = false;

            GetUserData userInfo = new GetUserData();

            userInfo = oAccountService.GetUserData(username, password);

            if (userInfo != null)
            {
                ctx.Session["LoginSuccessFlag"] = true;
                ctx.Session["accountid"] = userInfo?.Id;
                ctx.Session["role"] = userInfo?.Role;
                ctx.Session["name"] = userInfo?.Name;
                loginSuccessFlag = true;
            }

            return loginSuccessFlag;
        }
    }
}