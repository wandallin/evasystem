using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evasystem.DAL
{
    public class SampleDAL : BaseDAL
    {
        public UserInfoDTO GetUserInfo(string userId)
        {
            string sql = @"select * from [dbo].[ROG_Account] where [status] = 1 and userId = @userId";
            var result = this.DapperQueryFirstOrDefault<UserInfoDTO>(sql, new { userId });
            return result;
        }
    }
    // Sample用 可刪除
    public class UserInfoDTO
    {
        public int AccountId { get; set; }
        public string UserId { get; set; }
        public int Role { get; set; }
    }
}