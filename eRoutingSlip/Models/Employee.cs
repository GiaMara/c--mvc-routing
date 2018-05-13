using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eRoutingSlip.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int DivisionId { get; set; }
        public int AspNetUserId { get; set; }
    }
}