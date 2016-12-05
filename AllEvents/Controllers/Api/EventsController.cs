﻿using AllEvents.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;


namespace AllEvents.Controllers.Api
{
    [Authorize]
    public class EventsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var anEvent = _context.Events.Single(e => e.Id == id && e.CreatorId == userId);

            if (anEvent.IsCanceled)
                return NotFound();

            anEvent.IsCanceled = true;
            _context.SaveChanges();

            return Ok();
        }
    }
}
