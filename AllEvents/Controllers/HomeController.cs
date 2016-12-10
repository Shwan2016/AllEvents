using AllEvents.Models;
using AllEvents.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AllEvents.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(string query = null) 
        {
            var upcomingEvents = _context.Events
                .Include(e => e.Creator)
                .Include(e => e.EventType)
                .Where(e => e.DateTime > DateTime.Now &&  !e.IsCanceled);

            if (!string.IsNullOrWhiteSpace(query))
            {
                upcomingEvents =
                    upcomingEvents.Where(
                        e =>
                            e.Creator.Name.Contains(query) || 
                            e.EventType.Name.Contains(query) ||
                            e.Location.Contains(query));
            }

            var userId = User.Identity.GetUserId();
            var attandances = _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Event.DateTime > DateTime.Now)
                .ToList()
                .ToLookup(a => a.EventId); 


            var viewModel = new EventsViewModel
            {
                UpcomingEvents = upcomingEvents,
                ShowEvents = User.Identity.IsAuthenticated,
                SearchForEvent = query,
                Attendances = attandances
            };

            return View(viewModel); 
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}