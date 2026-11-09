
using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public int EventId { get; set; }

        public Event Event { get; set; } = null!;

        [Required]
        public string? Title { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; } = null!;

       

        public ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
    }
}
