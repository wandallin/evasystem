using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evasystem.DAL;
using evasystem.Models.DTOs;
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

        internal List<KeyinDataDTO> GetKeyinListData(string accountid)
        {
            return oFuncDAL.GetKeyinListData(accountid);
        }

        internal object GetKeyinData(string keyinId, string accountid)
        {
            return oFuncDAL.GetKeyinData(keyinId, accountid);
        }

        internal object KeyinEditSave(KeyinUpdateData data, string accountid)
        {
            return oFuncDAL.KeyinEditSave(data, accountid);
        }

        internal object GetCompleteListData(string accountid)
        {
            return oFuncDAL.GetCompleteListData(accountid);
        }
    }
}