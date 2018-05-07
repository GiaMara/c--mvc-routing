using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoutingSlip.Models
{
    public class Division
    {
        public int ID { get; set; }
        public string DivisionName { get; set; }
        public string DivisionHead { get; set; }
        public ICollection<RoutingSlip> RoutingSlips { get; set; }
    }
}