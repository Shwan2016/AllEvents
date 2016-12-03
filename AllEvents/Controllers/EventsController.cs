using AllEvents.Models;
using AllEvents.ViewModels;
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

        public ActionResult Create()
        {
            var viewModel = new EventFormViewModel
            {
                EventTypes = _context.EventTypes.ToList()
            };

            return View(viewModel);
        }
    }
}