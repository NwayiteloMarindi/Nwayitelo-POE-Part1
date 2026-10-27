using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Client.Models.DTOs;

public class DashboardDto
{
    // Counts
    public int UserCount { get; set; }
    public int EventCount { get; set; }
    public int CategoryCount { get; set; }
    public int EnrolmentCount { get; set; }
    public int ResultCount { get; set; }
    public int Payment { get; set; }
    public decimal TotalRevenue { get; set; }

    // Recent lists
    public List<EventDto> UpcomingEvents { get; set; } = new();
    public List<EventDto> AllEvents { get; set; } = new();
    public List<EventDto> EndedEvents { get; set; } = new ();
    public List<CategoryDto> Categories { get; set; } = new();
    public List<EnrolmentDto> RecentEnrolments { get; set; } = new();
    public List<ResultDto> RecentResults { get; set; } = new();
    public List<PaymentDto> Payments { get; set; } = new();
}

public class EventDto
{
    [ForeignKey("VenueId")]
    public int VenueId { get; set; }
    public required string Race_EventName { get; set; }
    public required DateOnly Race_EventDate { get; set; }
    public required string Description { get; set; }

    public required string Race_EventStatus { get; set; }
}

    public class CategoryDto
{
    public required string CategoryName { get; set; }
    public required string CategoryDescription { get; set; } = string.Empty;
}

public class EnrolmentDto
{
    public int Race_EventId { get; set; }
    [ForeignKey("RaceId")]
    public int RaceId { get; set; }
    public string? ParticipantName { get; set; }
    public string? ParticipantEmail { get; set; }
    public  string? ParticipantPhone { get; set; }
    public  string? ParticipantAddress { get; set; }
    public  string? ParticipantCity { get; set; }
    public  string? ParticipantProvince { get; set; }
    public string? ParticipantPostalCode { get; set; }
}

public class ResultDto
{
    public Guid ResultId { get; set; }
    public string? ParticipantName { get; set; }
    public string? FinishPosition { get; set; }
    public string? FinishTimeSeconds { get; set; }
}
public class PaymentDto
{

    [Required, Range(1, int.MaxValue)]
    public int EnrolmentId { get; set; }

    [Range(0.01, 1_000_000)]
    public decimal Amount { get; set; }

    [Required, StringLength(30)]
    public string PaymentMethod { get; set; } = "";   // Card | EFT | Cash

    [Required, StringLength(30)]
    public string PaymentStatus { get; set; } = "";   // Pending | Paid | Failed | Refunded

    [StringLength(100)]
    public string? Reference { get; set; }

   
    public DateTime? PaidAt { get; set; }
}