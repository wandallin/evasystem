using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evasystem.DAL;
using evasystem.Models.WebRequest;

namespace evasystem.Service
{
    public class FuncService
    {
        FuncDAL oFuncDAL = new FuncDAL();
        
        internal bool KeyinSave(KeyinData data, string accountid)
        {
            return oFuncDAL.KeyinSave(data, accountid);
        }
    }
}