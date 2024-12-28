using System.ComponentModel.DataAnnotations;

namespace TaskManagerBackend.Data.Entity
{
    public class Admin
    {
        public int AdminId { get; set; }

        [Required(ErrorMessage = "Email field is required!")]
        [EmailAddress(ErrorMessage = "Enter Valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [MaxLength(10)]
        [MinLength(10)]
        [Required(ErrorMessage = "Mobile number is required field")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "Enter valid full name")]
        public string FullName { get; set; }
    }
}
