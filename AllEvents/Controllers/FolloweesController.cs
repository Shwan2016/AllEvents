using AllEvents.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace AllEvents.Controllers
{
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FolloweesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var creators = _context.Followings
                .Where((f => f.FollowerId == userId))
                .Select(f => f.Followee)
                .ToList();

            return View(creators);
        }
        
    }
}
