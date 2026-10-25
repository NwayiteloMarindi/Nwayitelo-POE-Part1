using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_Day.Data;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;

namespace Race_Day.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbcontext dbcontext;
        public PaymentController(ApplicationDbcontext dbcontext) 
        { 
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetPayment()
        {
            var Bills = dbcontext.Payments.ToList();
            
            
            return Ok(Bills);
        }
        [HttpPost]
        public IActionResult ProcessPayment(AddPayment add)
        {
            var payment = new Payment
            {
                EnrolmentId = add.EnrolmentId,
                Amount = add.Amount,
                PaymentMethod = add.PaymentMethod,
                PaymentStatus = add.PaymentStatus,         
                Reference = add.Reference,
                PaidAt = add.PaidAt ?? DateTime.UtcNow,
                CreatedBy = User.Identity?.Name ?? "System"
            };
            dbcontext.Payments.Add(payment);
            dbcontext.SaveChanges();
            return Ok("Payment processed successfully");
        }
        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetPaymentStatus(string status)
        {
            
                if (string.IsNullOrWhiteSpace(status))
                    return BadRequest("Status is required.");

                // Normalize to match stored casing (if stored as "Paid", "Pending", etc.)
                var normalized = status.Trim();

                var payments = await dbcontext.Payments
                    .Where(p => p.PaymentStatus == normalized)
                    .Select(p => new
                    {
                        p.PaymentId,
                        p.EnrolmentId,
                        p.Amount,
                        p.PaymentMethod,
                        p.PaymentStatus,
                        p.Reference,
                        p.PaidAt
                    })
                    .ToListAsync();

                return Ok(payments);   // empty list is still a valid 200
            
        }
    }
}
