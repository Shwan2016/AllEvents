using AllEvents.Models;
using System;
using System.Collections.Generic;

namespace AllEvents.ViewModels
{
    public class EventFormViewModel
    {
        public string Location { get; set; }
        public string Description { get; set; } 
        public string  Date { get; set; }
        public string Time { get; set; }
        public int EventType { get; set; }
        public IEnumerable<EventType> EventTypes { get; set; }

        public DateTime DateTime => DateTime.Parse($"{Date} {Time}");
    }
} 