namespace Race_Day.Models.DTO
{
    public class CategoryDTO
    {
        public required string CategoryName { get; set; }
        public required string CategoryDescription { get; set; } = string.Empty;
    }
}
