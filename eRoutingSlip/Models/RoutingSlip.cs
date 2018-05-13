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
        [Required]
        public string DocumentName { get; set; }
        public string RequestingEmployee { get; set; } = System.Web.HttpContext.Current.User.Identity.Name;
        public DateTime DateSubmitted { get; set; } = DateTime.Now;

        [Required]
        public string ForwardTo { get; set; }

        public int DivisionID { get; set; }
        public LinkedListSignature LinkedListSignature { get; set; }
    }
}