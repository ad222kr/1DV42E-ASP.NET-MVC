using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAppMVC.Models
{
    public class Attendee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        
        public virtual Event Event { get; set; }
    }
}