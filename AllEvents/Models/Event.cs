using System;
using System.ComponentModel.DataAnnotations;

namespace AllEvents.Models
{
    public class Event
    {
        public int Id { get; set; }
        
        [Required] 
        public ApplicationUser Creator { get; set; }

        [Required]
        public string Description { get; set; }
         
        public DateTime DateTime { get; set; } 

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(255)]
        public string Address { get; set; }
        
        [StringLength(30)] 
        public string City { get; set; }

        [StringLength(3)]
        public string State { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }
        
        [Required] 
        public EventType EventType { get; set; } 
    }
} 