using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Event.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}