using System.ComponentModel.DataAnnotations;

namespace TVS.WebApp.ViewModels.Account
{

    public class RegisterViewModel
    {
        public TenantRegisterViewModel TenantVM { get; set; }
        public LandlordRegisterViewModel LandlordVM { get; set; }
        public SocietyRegisterViewModel SocietyVM { get; set; }
        
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

    }

    public class TenantRegisterViewModel : RegisterViewModelBase
    {
    }

    public class LandlordRegisterViewModel : RegisterViewModelBase
    {

    }


    public class SocietyRegisterViewModel : RegisterViewModelBase
    {

    }

  
}
