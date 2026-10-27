using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Models.DTO
{
    public class Race_EventDTO
    {
        [ForeignKey("VenueId")]
        public int VenueId { get; set; }
        public required string Race_EventName { get; set; }
        public required DateOnly Race_EventDate { get; set; }
        public required string Description { get; set; }

        public required string Race_EventStatus { get; set; }
    }
}
