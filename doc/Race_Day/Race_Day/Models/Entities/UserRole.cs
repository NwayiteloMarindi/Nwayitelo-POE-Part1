using Race_Day.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserRole
{
    [Key]
    public Guid UserRoleId { get; set; } = Guid.NewGuid();

    public int UserId { get; set; }        
    public Guid RoleId { get; set; }       

    public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
    public string AssignedBy { get; set; } = "";

    [ForeignKey(nameof(RoleId))]
    public Roles? Role { get; set; }
}