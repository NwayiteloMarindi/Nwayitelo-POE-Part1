using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Models.DTO
{
    public class UpdateEnrolment
    {

        [ForeignKey("Race_EventId")]
        public int Race_EventId { get; set; }
        [ForeignKey("RaceId")]
        public int RaceId { get; set; }
        public string? ParticipantName { get; set; }
        public  string? ParticipantEmail { get; set; }
        public string? ParticipantPhone { get; set; }
        public string? ParticipantPostalCode { get; set; }
        public string? ParticipantCountry { get; set; }
    }
}
