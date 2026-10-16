using System.ComponentModel.DataAnnotations;

namespace Race_Day.Models.Entities
{
    public class UserAccount
    {
        [Key]
        public int UserAccountId { get; set; }
        public required string UserAccountName { get; set; }
        public required string UserAccountEmail { get; set; }
        public required string UserAccountPassword { get; set; }
        public required string UserAccountRole { get; set; }
        public required string UserAccountPhone { get; set; }

    }
}
