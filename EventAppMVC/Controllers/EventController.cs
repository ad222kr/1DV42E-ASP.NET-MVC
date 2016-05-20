using EventAppMVC.Models;
using EventAppMVC.Models.DAL;
using EventAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventAppMVC.Controllers
{
    public class EventController : Controller
    {
        private UnitOfWork _unitOfWork = new UnitOfWork();
        // GET: Event
        public ActionResult Index()
        {
            var events = _unitOfWork.EventRepository.Get();
            var eventsViewModel = new EventViewModel
            {
                Events = events
            };
            return View(eventsViewModel);
        }

        // GET: /Event/Details/5
        public ActionResult Details(int id)
        {
            var theEvent = _unitOfWork.EventRepository.GetByID(id);
            return View(theEvent);
        }

        
    }
}