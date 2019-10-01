using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evasystem.Models.WebRequest
{
    public class KeyinUpdateData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string classname { get; set; }
        public string grade { get; set; }
        public string phone { get; set; }
        public string quest { get; set; }
        public int money { get; set; }
        public string contract { get; set; }
        public int keyintype { get; set; }
        public int status { get; set; }
        public DateTime askdate { get; set; }
        public DateTime trandate { get; set; }
    }
}