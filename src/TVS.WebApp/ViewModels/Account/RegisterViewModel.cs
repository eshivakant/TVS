using System.ComponentModel.DataAnnotations;

namespace TVS.WebApp.ViewModels.Account
{

    public class RegisterViewModel
    {
        public TenantRegisterViewModel TenantVM { get; set; }
        public LandlordRegisterViewModel LandlordVM { get; set; }
        public SocietyRegisterViewModel SocietyVM { get; set; }


        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

    }


    public class RegisterViewModelBase
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


        public string Role { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Gender")]
        public string Gender { get; set; }


        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }

        [Display(Name = "Landline Number")]
        public string Landline { get; set; }

        public Address PresentAddress { get; set; }

    }

    public class TenantRegisterViewModel : RegisterViewModelBase
    {
        public Address[] PreviousAddresses { get; set; }
    }

    public class LandlordRegisterViewModel : RegisterViewModelBase
    {

    }


    public class SocietyRegisterViewModel : RegisterViewModelBase
    {

    }

    public class Address
    {
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Present Address")]
        public string FullAddress { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Present Address City")]
        public string City { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Present Address Pin Code")]
        public string PinCode { get; set; }
    }
}
