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

            return RedirectToAction("Index", "Home");
        }
    }
}