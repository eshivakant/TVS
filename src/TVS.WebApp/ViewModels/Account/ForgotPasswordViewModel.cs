using System.ComponentModel.DataAnnotations;

namespace TVS.WebApp.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
