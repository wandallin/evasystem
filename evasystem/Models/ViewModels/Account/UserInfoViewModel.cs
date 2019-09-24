using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evasystem.Models.ViewModels.Account
{
    public class UserInfoViewModel
    {
        public int AccountId { get; set; }
        public string Login { get; set; }
        public string UserId { get; set; }
        public int Role { get; set; }
    }
}