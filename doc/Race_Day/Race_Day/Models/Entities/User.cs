using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace Race_Day.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Email { get; set; }
        public required  string Password { get; set; }
        public required string Role { get; set; }
        public required string Phone { get; set; }

    }
}
