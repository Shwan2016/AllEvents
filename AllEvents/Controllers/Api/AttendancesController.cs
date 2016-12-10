﻿using AllEvents.Dtos;
using AllEvents.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;


namespace AllEvents.Controllers.Api
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
            var exists = _context.Attendances
                .Any(a => a.AttendeeId == userId && a.EventId == dto.EventId);
 
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

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();

            var attendance = _context.Attendances
                .SingleOrDefault(a => a.AttendeeId == userId && a.EventId == id);

            if(attendance == null)
                return NotFound();

            _context.Attendances.Remove(attendance);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}
