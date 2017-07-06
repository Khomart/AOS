using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AOS.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
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
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class NewRegisterViewModel
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
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterContactViewModel
    {

        [Required]
        [Display(Name = "Account Type")]
        public OrganizationTypes Type { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        public string OrganizationName { get; set; }

        [Required]
        [Display(Name = "State")]
        public Countries Country { get; set; }

        //Personal

        [Required]
        [Display(Name = "Title")]
        public Title Title { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Given Name")]
        [Required]
        [StringLength(20, ErrorMessage = "The name should be at least 3 characters long", MinimumLength = 3)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Family Name")]
        [Required]
        [StringLength(20, ErrorMessage = "The name should be at least 3 characters long", MinimumLength = 3)]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Position")]
        public string JobTitle { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Language")]
        //[StringLength(20, ErrorMessage = "The name should be at least 3 characters long", MinimumLength = 3)]
        public Language Language { get; set; }

        //[Required]
        //[Display(Name = "Category")]
        //public OrganizationCategory OrganizationCategory { get; set; }

        //[Required]
        //[Display(Name = "State")]
        //public string State { get; set; }

        //[Required]
        //[Display(Name = "Unit")]
        //public OrganizationTypes OrganizationType { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

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
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
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
