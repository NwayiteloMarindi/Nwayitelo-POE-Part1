using System.ComponentModel.DataAnnotations;

namespace Race_Day.Models.DTO
{
    public class CreateUser
    {
        [Required]
        public required string Name { get; set; }

        [Required, EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string Role { get; set; }

        [Required, Phone]
        public required string Phone { get; set; }
    }
}
