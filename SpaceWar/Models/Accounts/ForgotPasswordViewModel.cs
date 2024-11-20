using System.ComponentModel.DataAnnotations;

namespace SpaceWar.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
