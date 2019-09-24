using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evasystem.DAL;

namespace evasystem.BAL
{
    public class LogService
    {
        LogDAL oLogDAL = new LogDAL();

        public void OpDbConnection()
        {
            oLogDAL.OpDbConnection();
        }
    }
}