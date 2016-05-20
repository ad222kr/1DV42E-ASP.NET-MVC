using EventAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventAppMVC.ViewModels
{
    public class EventViewModel
    {
        public IEnumerable<Event> Events { get; set; }
    }
}