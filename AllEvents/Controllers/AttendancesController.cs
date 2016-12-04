using AllEvents.Dtos;
using AllEvents.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace AllEvents.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext(); 
        }

        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto dto)  
        {
            var userId = User.Identity.GetUserId();
            var exists = _context.Attendances.Any(a => a.AttendeeId == userId && a.EventId == dto.EventId);
 
            if (exists)
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance
            {
                EventId = dto.EventId, 
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok();
        }
    }
}
