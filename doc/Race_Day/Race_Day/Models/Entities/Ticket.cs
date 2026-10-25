// Race_Day/Models/Entities/Ticket.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Race_Day.Models.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; } 

        public int EnrolmentId { get; set; }        
        public int CategoryId { get; set; }         

        public string TicketNumber { get; set; } = "";       
        public int BibNumber { get; set; }
        public string Status { get; set; } = "";             
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UsedAt { get; set; }

        [ForeignKey(nameof(EnrolmentId))]
        public Registration? Registration { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }
    }
}