using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Event.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام رویداد")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "زمان شروع")]
        public DateTime StartTime { get; set; }

        [Display(Name = "زمان پایان")]
        public DateTime FinishTime { get; set; }

        [Display(Name = "مکان رویداد")]
        public string Location { get; set; }

        [Display(Name = "تصویر رویداد")]
        public HttpPostedFileBase HttpPictures { get; set; }

        [Display(Name = "تصویر برگزار کنندگان")]
        public HttpPostedFileBase HttpOrganizers { get; set; }

        [Display(Name = "تصویر حامیان")]
        public HttpPostedFileBase HttpSponsor { get; set; }
    }
}
