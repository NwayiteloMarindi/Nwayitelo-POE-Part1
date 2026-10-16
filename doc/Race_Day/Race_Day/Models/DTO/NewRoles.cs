namespace Race_Day.Models.DTO
{
    public class NewRoleDTO
    {
        public required string RoleName { get; set; }
        public required string RoleDescription { get; set; } = string.Empty;
    }
}
