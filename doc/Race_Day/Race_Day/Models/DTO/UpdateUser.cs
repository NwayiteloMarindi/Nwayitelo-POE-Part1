namespace Race_Day.Models.DTO
{
    public class UpdateUser
    {
        
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required string Phone { get; set; }
    }
}
