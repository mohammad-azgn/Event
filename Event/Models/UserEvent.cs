using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event.Models
{
    public class UserEvent
    {
        
        [Key]
        [Column(Order = 0)]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Key]
        [Column(Order = 1)]
        public int EventId { get; set; }
        public Event Event { get; set; }

       
        public Request Request { get; set; }
    }

    public enum Request
    {
        Allow,
        Deny,
        None
    }
}