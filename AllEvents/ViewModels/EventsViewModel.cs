using System.Collections.Generic;
using AllEvents.Models;

namespace AllEvents.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcomingEvents { get; set; }
        public bool ShowEvents { get; set; }
    }
}