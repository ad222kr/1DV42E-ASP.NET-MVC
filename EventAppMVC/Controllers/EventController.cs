using EventAppMVC.Models.DAL;
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
            return View();
        }
    }
}