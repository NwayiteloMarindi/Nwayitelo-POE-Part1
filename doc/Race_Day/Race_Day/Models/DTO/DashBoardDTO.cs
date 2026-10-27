
namespace Race_Day.Client.Models.DTOs
{
    public class DashboardDto
    {
        // Dashboard counts
        public int UserCount { get; set; }
        public int EventCount { get; set; }
        public int CategoryCount { get; set; }
        public int EnrolmentCount { get; set; }
        public int ResultCount { get; set; }

        // Financial summary
        public decimal TotalRevenue { get; set; }

        // Dashboard lists
        public List<EventDto> UpcomingEvents { get; set; } = new();
        public List<CategoryDto> Categories { get; set; } = new();
        public List<EnrolmentDto> RecentEnrolments { get; set; } = new();
        public List<ResultDto> RecentResults { get; set; } = new();
        public List<PaymentDto> Payments { get; set; } = new();
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
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
    }

    public class EnrolmentDto
    {
        public int EnrolmentId { get; set; }
        public string UserName { get; set; } = "";
        public string EventName { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string EnrolmentStatus { get; set; } = "";
        public string PaymentStatus { get; set; } = "";
        public decimal AmountPaid { get; set; }
        public DateTime EnrolmentDate { get; set; }
    }

    public class PaymentDto
    {
        public int EnrolmentId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = "";
        public string PaymentStatus { get; set; } = "";
        public string? Reference { get; set; }
        public DateTime? PaidAt { get; set; }
    }

    public class ResultDto
    {
        public int ResultId { get; set; }
        public string? ParticipantName { get; set; }
        public string? FinishPosition { get; set; }
        public string? FinishTimeSeconds { get; set; }
    }
}
