using AllEvents.Models;
using AllEvents.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AllEvents.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Mine()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Events
                .Where(e => e.CreatorId == userId && e.DateTime > DateTime.Now)
                .Include(e => e.EventType)
                .ToList();

            return View(events);
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Event)
                .Include(e => e.Creator)
                .Include(e => e.EventType)
                .ToList();

            var viewModel = new EventsViewModel 
            {
                UpcomingEvents = events,
                ShowEvents = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }


        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                EventTypes = _context.EventTypes.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.EventTypes = _context.EventTypes.ToList();
                return View("Create", viewModel);
            }
            var anEvent = new Event
            {
                CreatorId = User.Identity.GetUserId(),
                Location = viewModel.Location,
                Description = viewModel.Description,
                DateTime = viewModel.GetDateTime(),
                EventTypeId = viewModel.EventType
            };

            _context.Events.Add(anEvent);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Events");
        }
    }
}