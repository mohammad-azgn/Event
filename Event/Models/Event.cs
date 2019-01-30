using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Event.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Pictures { get; set; }
    
        [Required]
        public string Organizers { get; set; }

        [Required]
        public string Sponsor { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime FinishTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Location { get; set; }

        public Category Category { get; set; }
        public int? CategoryId { get; set; }


        public ICollection<UserEvent> UserEvent { get; set; }
    }
}