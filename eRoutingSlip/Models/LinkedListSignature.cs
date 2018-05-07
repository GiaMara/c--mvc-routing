using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eRoutingSlip.Models
{
    public class LinkedListSignature
    {
        public int ID { get; set; } 
        //public LinkedListSignatureNode Head { get; set; }
        public List<LinkedListSignatureNode> LLSNodes { get; set; }
        public int RoutingSlipID { get; set; }
        // public LinkedListSignatureNode Current  { get; set; }
        public string CurrentName { get; set; }
    }
}
