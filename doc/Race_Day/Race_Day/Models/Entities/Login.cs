using System.ComponentModel.DataAnnotations;

namespace Race_Day.Models.Entities
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }
        public required string UserAccountEmail { get; set; }
        public required string UserAccountPassword { get; set; }
    }
}
