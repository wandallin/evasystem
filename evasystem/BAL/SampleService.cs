using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using evasystem.DAL;
using evasystem.Models.ViewModels;

namespace evasystem.BAL
{
    public class SampleService
    {
        SampleDAL oSampleDAL = new SampleDAL();

        public List<SampleObjViewModel> GetSampleInfo()
        {
            List<SampleObjViewModel> results = new List<SampleObjViewModel>();
            var tmpDbInfo = oSampleDAL.GetUserInfo("ABC");

            results.Add(new SampleObjViewModel()
            {
                 Id  = tmpDbInfo.UserId,
                  Name = tmpDbInfo.UserId
            });

            return results;
        }

    }
}