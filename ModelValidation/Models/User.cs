using System.ComponentModel.DataAnnotations;

namespace ModelValidation.Models
{
    public class User
    {
        [Required]
        [StringLength(50,ErrorMessage="Max length : 50",MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength( 50, ErrorMessage = "Max length : 50", MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Max length : 15", MinimumLength = 6)]
        [RegularExpression(@"^.*(?=.{6,15})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$",ErrorMessage = "At least 7 chars,At least 1 uppercase char (A-Z),At least 1 number (0-9),At least one special char,At Most 15 chars")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Check your password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Range(18,100,ErrorMessage = "Max age : 100 , min age: 18 ")]
        public int BirthYear { get; set; }
        [CreditCard]
        public string CreditCard { get; set; }
        [Url]
        public string FacebookProfileUrl { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
    }
}