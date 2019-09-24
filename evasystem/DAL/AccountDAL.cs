using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evasystem.Models.ViewModels;

namespace evasystem.DAL
{
    public class AccountDAL : BaseDAL
    {
        internal GetUserData GetUsetData(string username, string password)
        {
            string sql = @"

SELECT * FROM Users where Account = @username and Password = @password

";
            var result = this.DapperQueryFirstOrDefault<GetUserData>(sql, new { username, password });
            return result;
        }
    }
}