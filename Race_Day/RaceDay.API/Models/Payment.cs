using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        [Required]
        public int EnrolmentId { get; set; }
        public Enrolment Enrolment { get; set; } = null!;
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required, MaxLength(50)]
        public string PaymentMethod { get; set; } = null!;
        
        [Required]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        [Required]
        public string Status { get; set; } = null!;
        [Required]

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}