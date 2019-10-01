using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evasystem.Models.TableSchema
{
    [Table("KeyinData")]
    public class DeleteKeyinData
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int AccountId { get; set; }
    }
}