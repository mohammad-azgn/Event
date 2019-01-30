using System.Collections.Generic;
using System.Web;
using Event.Models;

namespace Event.ViewModels
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }

        public HttpPostedFileBase HttpPostedFileBase { get; set; }

        public List<UserEvent> UserEvents { get; set; }


    }
}