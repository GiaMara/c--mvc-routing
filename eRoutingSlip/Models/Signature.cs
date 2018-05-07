using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eRoutingSlip.Models
{
    public class Signature
    {
        public int SignatureID { get; set; }
        public string SignatureName { get; set; }
        public DateTime DateRouted { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public int RoutingSlipID { get; set; }
    }
}