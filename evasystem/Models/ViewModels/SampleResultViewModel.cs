using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace evasystem.Models.ViewModels
{
    public class SampleResultViewModel
    {
        public List<SampleObjViewModel> Obj { get; set; } = new List<SampleObjViewModel>();
    }
    public class SampleObjViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}