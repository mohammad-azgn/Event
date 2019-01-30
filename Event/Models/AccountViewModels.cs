using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Event.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required] public string Provider { get; set; }

        [Required] [Display(Name = "Code")] public string Code { get; set; }

        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required] [Display(Name = "Email")] public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید.")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل معتبر نیست.")]
        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage = "رمز عبور را وارد کنید.")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }


        [Display(Name = "مرا به خاطر بسپار.")] public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "نام را وارد کنید.")]
        [StringLength(50)]
        [Display(Name = "نام")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "نام خانوادگی را وارد کنید.")]
        [StringLength(50)]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "آدرس ایمیل را وارد کنید.")]
        [EmailAddress(ErrorMessage = "آدرس ایمیل معتبر نیست.")]
        [Display(Name = "آدرس ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage = "کد ملی را وارد کنید.")]
        [Display(Name = "کد ملی")]
        public string NationalId { get; set; }


        [Required(ErrorMessage = "شماره تلفن را وارد کنید.")]
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "رمز عبور را وارد کنید.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage =
            "رمز عبور و تکرار آن برابر نیستند.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage =
            "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}