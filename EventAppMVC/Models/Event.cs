using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace EventAppMVC.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int VenueID { get; set; }

        public virtual Venue Venue { get; set; }

    }
}