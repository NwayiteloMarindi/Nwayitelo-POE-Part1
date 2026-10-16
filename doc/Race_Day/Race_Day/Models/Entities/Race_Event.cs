using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Models.Entities
{
    public class Race_Event
    {
        [Key]
        public int Race_EventId { get; set; }
        [ForeignKey("VenueId")]
        public int VenueId { get; set; }
        public required string Race_EventName { get; set; }
        public required DateOnly Race_EventDate { get; set; }
        public required string Description { get; set; }

        public required string Race_EventStatus { get; set; }

    }
}
