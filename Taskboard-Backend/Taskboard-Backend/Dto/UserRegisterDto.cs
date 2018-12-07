using System.ComponentModel.DataAnnotations;

namespace WebApi.Dto
{
    public class UserRegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 4, ErrorMessage = "Your must specified fullname at least 4 characters length")]
        public string FullName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Your must specified password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}
