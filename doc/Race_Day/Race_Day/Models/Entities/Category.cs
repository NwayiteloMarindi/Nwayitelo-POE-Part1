using System.ComponentModel.DataAnnotations;

namespace Race_Day.Models.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId   { get; set; }
        public required string CategoryName { get; set; }
        public required string CategoryDescription { get; set; }
        

    }
}
