using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoutingSlip.Models
{
    public class RoutingSlipSignatureViewModel
    {
        public int RoutingSlipID { get; set; }
        public string DocumentName { get; set; }
        public string RequestingEmployee { get; set; } 
        public DateTime DateSubmitted { get; set; }
        public string CurrentName { get; set; }
    }
}