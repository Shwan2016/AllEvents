using AllEvents.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AllEvents.ViewModels
{
    public class EventFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [UpComingDate]
        public string  Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public int EventType { get; set; }

        public IEnumerable<EventType> EventTypes { get; set; }

        public string Heading { get; set; }

        public string Action => (Id != 0) ? "Update" : "Create";

        [Required]
        public string Image { get; set; }

        public DateTime GetDateTime() => DateTime.Parse($"{Date} {Time}");
    }
}  