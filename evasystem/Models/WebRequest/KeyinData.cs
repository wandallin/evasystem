﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evasystem.Models.WebRequest
{
    public class KeyinData
    {
        public string name { get; set; }
        public string classname { get; set; }
        public string grade { get; set; }
        public string phone { get; set; }
        public string quest { get; set; }
        public int money { get; set; }
        public string contract { get; set; }
        public int type { get; set; }
        public int status { get; set; }
        public DateTime askdate { get; set; }
        public DateTime trandate { get; set; }
    }
}