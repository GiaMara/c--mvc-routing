using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eRoutingSlip.Models
{
    public class RoutingSlip
    {
        public int RoutingSlipID { get; set; }
        public string DocumentName { get; set; }
        public string RequestingEmployee { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public string ForwardTo { get; set; }
        public int DivisionID { get; set; }
        public LinkedListSignature LinkedListSignature { get; set; }
    }
}