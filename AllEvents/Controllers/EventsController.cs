using AllEvents.Models;
using AllEvents.ViewModels;
using Microsoft.AspNet.Identity;
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
        public ActionResult Create(EventFormViewModel viewModel)
        {
            var anEvent = new Event
            {
                CreatorId = User.Identity.GetUserId(),
                Description = viewModel.Description,
                DateTime = viewModel.DateTime,
                EventTypeId = viewModel.EventType,
                Location = viewModel.Location
            };

            _context.Events.Add(anEvent);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}