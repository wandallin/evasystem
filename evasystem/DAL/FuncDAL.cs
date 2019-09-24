﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evasystem.Models.TableSchema;
using evasystem.Models.WebRequest;

namespace evasystem.DAL
{
    public class FuncDAL : BaseDAL
    {
        internal bool KeyinSave(KeyinData data, string accountid)
        {
            InsertKeyinData insertKeyinData = new InsertKeyinData()
            {
               Name = data.name,
               Classname = data.classname,
               Phone = data.phone,
               Quest = data.quest,
               Type = data.type,
               Status = data.status,
               Askdate = data.askdate,
               Trandate = data.trandate,
               AccountId = Convert.ToInt32(accountid),

            };

            bool result = DapperInsert(insertKeyinData) > 0;
            return result;
        }
    }
}