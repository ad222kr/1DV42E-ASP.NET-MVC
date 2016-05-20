using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAppMVC.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Attendee> Attendees { get; set; }
    }
}