namespace Race_Day.Client.Models.DTOs;

public class DashboardDto
{
    // Counts
    public int UserCount { get; set; }
    public int EventCount { get; set; }
    public int CategoryCount { get; set; }
    public int EnrolmentCount { get; set; }
    public int ResultCount { get; set; }
    public decimal TotalRevenue { get; set; }

    // Recent lists
    public List<EventDto> UpcomingEvents { get; set; } = new();
    public List<CategoryDto> Categories { get; set; } = new();
    public List<EnrolmentDto> RecentEnrolments { get; set; } = new();
    public List<ResultDto> RecentResults { get; set; } = new();
}

public class EventDto
{
    public Guid EventId { get; set; }
    public string EventName { get; set; } = "";
    public DateTime EventDate { get; set; }
    public string Location { get; set; } = "";
    public string Status { get; set; } = "";
}

public class CategoryDto
{
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = "";
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string GenderRestrictions { get; set; } = "";
    public int MaxParticipants { get; set; }
    public string CreatedBy { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}

public class EnrolmentDto
{
    public Guid EnrolmentId { get; set; }
    public string UserName { get; set; } = "";
    public string EventName { get; set; } = "";
    public string CategoryName { get; set; } = "";
    public string EnrolmentStatus { get; set; } = "";
    public string PaymentStatus { get; set; } = "";
    public decimal AmountPaid { get; set; }
    public DateTime EnrolmentDate { get; set; }
}

public class ResultDto
{
    public Guid ResultId { get; set; }
    public string? ParticipantName { get; set; }
    public string? FinishPosition { get; set; }
    public string? FinishTimeSeconds { get; set; }
}