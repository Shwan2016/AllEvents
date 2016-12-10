using AllEvents.Models;
using System.Collections.Generic;
using System.Linq;

namespace AllEvents.ViewModels
{
    public class EventsViewModel
    {
        public IEnumerable<Event> UpcomingEvents { get; set; }
        public bool ShowEvents { get; set; }
        public string SearchForEvent { get; set; }
        public ILookup<int, Attendance> Attendances { get; set; }
    }
}  