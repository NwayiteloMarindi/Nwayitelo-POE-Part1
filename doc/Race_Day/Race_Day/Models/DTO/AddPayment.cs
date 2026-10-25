using System.ComponentModel.DataAnnotations;

namespace Race_Day.Models.DTO
{
    public class AddPayment
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

        // Server-set (not trusted from client); kept optional for back-dated imports
        public DateTime? PaidAt { get; set; }
    }
}