using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evasystem.Models.DTOs
{
    public class KeyinDataDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Classname { get; set; }
        public string Phone { get; set; }
        public string Quest { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public DateTime Askdate { get; set; }
        public DateTime Trandate { get; set; }
        public int AccountId { get; set; }
        public string Grade { get; set; }
        public int Money { get; set; }
        public string Contract { get; set; }
    }
}