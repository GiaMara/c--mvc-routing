using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eRoutingSlip.Models
{
    public class LinkedListSignatureNode
    {
        public virtual int ID { get; set; }
        public virtual Signature Data { get; set; }

        public virtual LinkedListSignatureNode PrevSNode { get; set; }
        public virtual LinkedListSignatureNode NextSNode { get; set; }

        public virtual int RoutingSlipID { get; set; }

        [InverseProperty("PrevSNode")]
        public virtual ICollection<LinkedListSignatureNode> PrevSNodes { get; set; }
        [InverseProperty("NextSNode")]
        public virtual ICollection<LinkedListSignatureNode> NextSNodes { get; set; }
    }



}