//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eRoutingSlip
{
    using System;
    using System.Collections.Generic;
    
    public partial class Signature
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Signature()
        {
            this.LinkedListSignatureNodes = new HashSet<LinkedListSignatureNode>();
        }
    
        public int SignatureID { get; set; }
        public string SignatureName { get; set; }
        public System.DateTime DateRouted { get; set; }
        public string Status { get; set; }
        public int RoutingSlipID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LinkedListSignatureNode> LinkedListSignatureNodes { get; set; }
    }
}
