using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Models.Entities
{
    public class Race
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Race_EventId")]
        public int Race_EventId { get; set; }
        public required string Race_name { get; set; }
        public required string Race_Number { get; set; }
        public required string Race_distance { get; set; }
        public required TimeOnly Race_time { get; set; }
        public required string Race_Description { get; set; }
    }
}
