using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAppMVC.Models
{
    public class Venue
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}