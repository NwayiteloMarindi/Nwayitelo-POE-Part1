using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Models.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [ForeignKey("Race_EventId")]
        public int Race_EventId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public required string TicketType { get; set; }
        public required decimal TicketPrice { get; set; }
        public string? TicketName { get; set; }
        public string? TicketDescription { get; set; }
        public required DateOnly PurchaseDate { get; set; }
        public required string TicketStatus { get; set; }
    }
}
