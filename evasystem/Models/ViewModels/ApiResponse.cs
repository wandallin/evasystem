using evasystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static evasystem.Models.Enums.EnumClass;

namespace evasystem.Models.ViewModels
{
    public class ApiResponse : ApiResponse<object>
    {
        public ApiResponse()
        {

        }
        public ApiResponse(Enum status)
        {
            this.Status = status.ToString();
            this.Message = status.ToString();
        }
        public ApiResponse(Enum status, string ErrorMsg)
        {
            this.Status = status.ToString();
            this.Message = ErrorMsg;
        }
    }
    public class ApiResponse<T>
            where T : new()
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public ApiResponse()
        {
            this.Status = SetStatus(EnumApiStatus.Success);
            this.Message = EnumHelper.GetEnumDisplayName(EnumApiStatus.Success);
            this.Result = Activator.CreateInstance<T>();
        }
        public ApiResponse(Enum status)
        {
            this.Status = SetStatus(status);
            this.Message = EnumHelper.GetEnumDisplayName(status);
            this.Result = Activator.CreateInstance<T>();
        }
        public void ErrorSetting(string errorMsg = "")
        {
            this.Status = EnumApiStatus.Fail.ToString();
            this.Message = "";
        }
        private string SetStatus(Enum status)
        {
            return (Convert.ToInt32(status)).ToString();
        }
    }
}