using System.ComponentModel.DataAnnotations;

namespace Race_Day.Models.Entities
{
    public class Roles
    {
        [Key]
        public  Guid RoleId { get; set; }= Guid.NewGuid();
        public required string  RoleName { get; set; }
        public required string RoleDescription { get; set; }
    }
}
