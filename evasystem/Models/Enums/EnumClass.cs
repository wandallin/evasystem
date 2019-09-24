using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace evasystem.Models.Enums
{
    public static class BackendEnumClass
    {
        public enum Log_Type
        {
            Success = 1,
            Error,
            API,
            API_Error,
        }
    }
    public static class EnumClass
    {
        /// <summary>
        /// API 回傳Code語意轉換
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum EnumApiStatus
        {
            /// <summary>
            /// Success
            /// </summary>
            [Display(Name = "Success")]
            Success = 0,
            /// <summary>
            /// 資料庫連線或SQL運作發生錯誤
            /// </summary>
            [Display(Name = "Errors when connecting database")]
            DB_Error = 1,
            /// <summary>
            /// API 參數錯誤, 空白或輸入內容不被允許
            /// </summary>
            [Display(Name = "Errors with wrong, empty or not allowed parameters")]
            API_ParameterError = 2,
            /// <summary>
            /// 資料重複建立或所建立的資料已經存在
            /// </summary>
            [Display(Name = "Repeated data creating or existing the data record")]
            DataExist = 3,
            /// <summary>
            /// 沒有足夠的權限完成動作
            /// </summary>
            [Display(Name = "Don't have authorization to complete the request")]
            NoAuth = 4,
            /// <summary>
            /// Aticket_Expire
            /// </summary>
            [Display(Name = "Aticket expire")]
            Aticket_Expire = 5,
            /// <summary>
            /// API_Token無效 (該 tokentoken token 無效 )
            /// </summary>
            [Display(Name = "Access denied by token")]
            Access_Denied_By_Token = 6,
            /// <summary>
            /// Token_Expire
            /// </summary>
            [Display(Name = "Token expire")]
            Token_Expire = 7,
            /// <summary>
            /// UserDataNotFound(資料不存在)
            /// </summary>
            [Display(Name = "Data not found")]
            UserDataNotFound = 8,
            /// <summary>
            /// Backend Error
            /// </summary>
            [Display(Name = "Backend Error")]
            Backend_Error = 99,
            [Display(Name = "Fail")]
            Fail = 999,
        }
    }
}