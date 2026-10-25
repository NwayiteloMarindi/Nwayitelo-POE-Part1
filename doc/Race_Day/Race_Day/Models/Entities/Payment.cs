
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Models.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } 

        public int EnrolmentId { get; set; }        // FK → Registrations (Enrolments)

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = "";   // Card, EFT, Cash
        public string PaymentStatus { get; set; } = "";   // Pending, Paid, Failed, Refunded
        public string? Reference { get; set; }            // gateway ref / invoice no
        public DateTime PaidAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = "";

        // Navigation
        [ForeignKey(nameof(EnrolmentId))]
        public Registration? Registration { get; set; }
    }
}