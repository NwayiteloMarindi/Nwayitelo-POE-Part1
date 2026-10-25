using System.ComponentModel.DataAnnotations;

public class ParticipantEvent
{
    [Key]
    public int Participant_EventId { get; set; } 

    public int UserId { get; set; }
    public int EventId { get; set; }
    public int CategoryId { get; set; }

    public int BibNumber { get; set; }
    public int FinishPosition { get; set; }
    public TimeSpan FinishTime { get; set; }
    public string EntryStatus { get; set; } = "";
    public DateTime EnteredAt { get; set; } = DateTime.UtcNow;
}