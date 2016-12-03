using System.ComponentModel.DataAnnotations;

namespace AllEvents.Models
{
    public class EventType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } 
    }
} 