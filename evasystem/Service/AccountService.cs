using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evasystem.DAL;
using evasystem.Models.ViewModels;
using evasystem.Models.ViewModels.Account;

namespace evasystem.Service
{
    public class AccountService
    {
        AccountDAL accountDAL = new AccountDAL();

        internal GetUserData GetUserData(string username, string password)
        {
            return accountDAL.GetUsetData(username, password);
        }
    }
}