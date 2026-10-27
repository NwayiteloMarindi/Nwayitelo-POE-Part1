using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Data;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;

namespace Race_Day.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrolmentController : ControllerBase
    {
        private readonly ApplicationDbcontext _dbcontext;
        public EnrolmentController(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllEnrolments()
        {
            var enrolments = _dbcontext.registrations.ToList();
            return Ok(enrolments);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEnrolmentById(Guid id)
        {
            var enrolment = _dbcontext.registrations.Find(id);
            if (enrolment == null) return NotFound($"No enrolment was found with {id}");
            return Ok(enrolment);
        }
        [HttpPost]
        public IActionResult AddNewEnrolment(EnrolmentDTO enrolmentDTO)
        {
            var newEnrolment = new Registration
            {
                Race_EventId = enrolmentDTO.Race_EventId,
                ParticipantEmail= enrolmentDTO.ParticipantEmail,
                RaceId = enrolmentDTO.RaceId,
                ParticipantName = enrolmentDTO.ParticipantName,
                ParticipantPhone = enrolmentDTO.ParticipantPhone,
                ParticipantAddress = enrolmentDTO.ParticipantAddress,
                ParticipantCity = enrolmentDTO.ParticipantCity,
                ParticipantProvince = enrolmentDTO.ParticipantProvince,
                ParticipantPostalCode = enrolmentDTO.ParticipantPostalCode,
                
            };
            _dbcontext.registrations.Add(newEnrolment);
            _dbcontext.SaveChanges();
            return Ok("Enrolment was added successfully");
        }
        
        [HttpPut("{id:guid}")]
        public IActionResult UpdateEnrolment(Guid id, EnrolmentDTO enrolmentDTO)
        {
            var enrolment = _dbcontext.registrations.Find(id);
            if (enrolment == null) return NotFound($"No enrolment was found with {id}");
            if (enrolmentDTO.Race_EventId != 0) enrolment.Race_EventId = enrolmentDTO.Race_EventId;
            if (enrolmentDTO.RaceId != 0) enrolment.RaceId = enrolmentDTO.RaceId;
            if (enrolmentDTO.ParticipantName != null) enrolment.ParticipantName = enrolmentDTO.ParticipantName;
            if (enrolmentDTO.ParticipantEmail != null) enrolment.ParticipantEmail = enrolmentDTO.ParticipantEmail;
            if (enrolmentDTO.ParticipantPhone != null) enrolment.ParticipantPhone = enrolmentDTO.ParticipantPhone;
            if (enrolmentDTO.ParticipantAddress != null) enrolment.ParticipantAddress = enrolmentDTO.ParticipantAddress;
            if (enrolmentDTO.ParticipantCity != null) enrolment.ParticipantCity = enrolmentDTO.ParticipantCity;
            if (enrolmentDTO.ParticipantProvince != null) enrolment.ParticipantProvince = enrolmentDTO.ParticipantProvince;
            if (enrolmentDTO.ParticipantPostalCode != null) enrolment.ParticipantPostalCode = enrolmentDTO.ParticipantPostalCode;
            _dbcontext.SaveChanges();
            return Ok("Enrolment was updated successfully");
        }
        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEnrolment(Guid id)
        {
            var enrolment = _dbcontext.registrations.Find(id);
            if (enrolment == null) return NotFound($"No enrolment was found with {id}");
            _dbcontext.registrations.Remove(enrolment);
            _dbcontext.SaveChanges();
            return Ok("Enrolment was deleted successfully");
        }

    }
}
