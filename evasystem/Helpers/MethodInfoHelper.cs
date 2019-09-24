using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace evasystem.Helpers
{
    public static class MethodInfoHelper
    {
        /// <summary>
        /// 取得 目前正在執行的 Function Info 資訊
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentMethodInfo()
        {
            string showString = "";
            //取得當前方法類別命名空間名稱
            showString += "Namespace:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace + "\n";
            //取得當前類別名稱
            showString += "class Name:" + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName + "\n";
            //取得當前所使用的方法
            showString += "Method:" + System.Reflection.MethodBase.GetCurrentMethod().Name + "\n";

            return showString;
        }
        /// <summary>
        /// 取得父類別的相關資訊(共用的Functiond可用)
        /// </summary>
        /// <returns></returns>
        public static string GetParentInfo(InfoMode infoMode)//ParentInfoMode InfoMode
        {
            string showString = "";
            StackTrace ss = new StackTrace(true);
#if DEBUG
            //取得呼叫當前方法之上 2 層類別(GetFrame(1))的屬性
            MethodBase mb = ss.GetFrame(2).GetMethod();
#else
            //取得呼叫當前方法之上 1 層類別(GetFrame(1))的屬性
            MethodBase mb = ss.GetFrame(1).GetMethod();
#endif
            switch (infoMode)
            {
                case InfoMode.Namespace:
                    //取得呼叫當前方法之上一層類別(父方)的命名空間名稱
                    showString += mb.DeclaringType.Namespace + "\n";
                    break;
                case InfoMode.ParentName:
                    //取得呼叫當前方法之上一層類別(父方)的function 所屬class Name
                    showString += mb.DeclaringType.Name + "\n";
                    break;
                case InfoMode.FullName:
                    //取得呼叫當前方法之上一層類別(父方)的Full class Name
                    showString += mb.DeclaringType.FullName + "\n";
                    break;
                case InfoMode.Name:
                default:
                    //取得呼叫當前方法之上一層類別(父方)的Function Name
                    showString += mb.Name + "\n";
                    break;
            }
            return showString;
        }
        public enum InfoMode
        {
            Namespace,
            ParentName,
            FullName,
            Name
        }
    }
}