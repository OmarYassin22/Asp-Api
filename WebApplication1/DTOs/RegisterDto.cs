using System.ComponentModel.DataAnnotations;

namespace Talabat.presentations.DTOs
{
    public class RegisterDto
    {

        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        //[RegularExpression(@"^.* (?=.{8,})(?=.*[\d])(?=.*[\W]).*$",
        //    ErrorMessage = " contains at least 8 characters - contains at least one digit - contains at least one special characte")]
        public string Password { get; set; }

    }
}