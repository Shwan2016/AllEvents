using AllEvents.Models;
using AllEvents.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
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
                .Where(e => 
                e.CreatorId == userId && 
                e.DateTime > DateTime.Now && 
                !e.IsCanceled)
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

            var attandances = _context.Attendances
                .Where(a => a.AttendeeId == userId && a.Event.DateTime > DateTime.Now)
                .ToList()
                .ToLookup(a => a.EventId);

            var viewModel = new EventsViewModel 
            {
                UpcomingEvents = events,
                ShowEvents = User.Identity.IsAuthenticated,
                Attendances = attandances 
            };
              
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(EventsViewModel viewModel)
        {
             
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchForEvent });
        }


        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                EventTypes = _context.EventTypes.ToList(),
                Heading = "Add an Event"
            };

            return View("EventForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var events = _context.Events.Single(e => e.Id == id && e.CreatorId == userId);

            var viewModel = new EventFormViewModel
            {
                Heading = "Eidt an Event",
                Id = events.Id,
                EventTypes = _context.EventTypes.ToList(),
                Date = events.DateTime.ToString("d MMM yyyy"),
                Time = events.DateTime.ToString("HH:mm"),
                EventType = events.EventTypeId,
                Location = events.Location,
                Description = events.Description,
                Image = events.Image,
                Price = events.Price

            };

            return View("EventForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(EventFormViewModel viewModel, HttpPostedFileBase Image)
        {
            if (!ModelState.IsValid)
            {               
                viewModel.EventTypes = _context.EventTypes.ToList();
                return View("EventForm", viewModel); 
            }
            FileInfo sllaw = new FileInfo(Image.FileName);
            string photo = Guid.NewGuid().ToString("N") + sllaw.Extension;
            Image.SaveAs(Server.MapPath("~/Content/Upload/Image/" + photo));
            viewModel.Image = photo;


            var anEvent = new Event
            {
                CreatorId = User.Identity.GetUserId(),
                Location = viewModel.Location,
                Description = viewModel.Description,
                Image = photo,
                Price = viewModel.Price,
                DateTime = viewModel.GetDateTime(),
                EventTypeId = viewModel.EventType
            };

            _context.Events.Add(anEvent);
            _context.SaveChanges();

            return RedirectToAction("Mine", "Events");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(EventFormViewModel viewModel) 
        {
            if (!ModelState.IsValid)
            {
                viewModel.EventTypes = _context.EventTypes.ToList();
                return View("EventForm", viewModel);
            }
            var userId = User.Identity.GetUserId();
            var anEvent = _context.Events.Single(e => e.Id == viewModel.Id && e.CreatorId == userId);
            anEvent.Location = viewModel.Location;
            anEvent.Description = viewModel.Description;
            anEvent.Image = viewModel.Image;
            anEvent.Price = viewModel.Price;
            anEvent.DateTime = viewModel.GetDateTime();
            anEvent.EventTypeId = viewModel.EventType; 
           
            _context.SaveChanges();

            return RedirectToAction("Mine", "Events");
        }

        public ActionResult Details(int id)
        {
            var anEvent = _context.Events
                .Include(e => e.Creator)
                .Include(e => e.EventType)
                .SingleOrDefault(e => e.Id == id);
            if (anEvent == null)
                return HttpNotFound();

            var viewModel = new EventDetailsViewModel {Event = anEvent};

            if (User.Identity.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();

                viewModel.IsAttending = _context.Attendances
                    .Any(a => a.EventId == anEvent.Id && a.AttendeeId == userId);

                viewModel.IsFollowing = _context.Followings
                    .Any(f => f.FolloweeId == anEvent.CreatorId && f.FollowerId == userId);
            }

            return View("Details", viewModel);

        }
    }
}