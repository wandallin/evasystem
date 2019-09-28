using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evasystem.Models.DTOs;
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
               Contract = data.contract,
               Grade = data.grade,
               Money = data.money,

            };

            bool result = DapperInsert(insertKeyinData) > 0;
            return result;
        }

        internal List<KeyinDataDTO> GetKeyinListData(string accountid)
        {
            string sql = @"
SELECT * FROM [eva-db].[dbo].[KeyinData] where AccountId = @accountid
";
            var result = this.DapperQuery<KeyinDataDTO>(sql, new { accountid }).ToList();
            return result;
        }

        internal KeyinDataDTO GetKeyinData(string keyinId, string accountid)
        {
            string sql = @"
SELECT * FROM [eva-db].[dbo].[KeyinData] where Id=@keyinId and AccountId = @accountid
";
            var result = this.DapperQueryFirstOrDefault<KeyinDataDTO>(sql, new { keyinId, accountid });
            return result;
        }
    }
}