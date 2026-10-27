using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Race_Day.Data;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;
using System.Threading.Tasks;

namespace Race_Day.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbcontext _dbcontext;
        public EventController(ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllEvents()
        {
           var events = _dbcontext.race_Events.ToList();
            return Ok(events);
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEventById(Guid id)
        {
            // Logic to retrieve an event by ID
            return Ok($"Event with ID {id} retrieved successfully");
        }
        [HttpGet]
        [Route("category/{categoryId:int}")]
        public IActionResult GetEventsByCategoryId(int categoryId)
        {
            var events = _dbcontext.race_Events
                .Where(e => e.VenueId == categoryId)
                .Select(e => new
                {
                    e.Race_EventId,
                    e.Race_EventName,
                    e.Race_EventDate,
                    e.Description,
                    e.Race_EventStatus
                }).ToList();

            return Ok($"Events for category ID {categoryId} retrieved successfully");
        }
        [HttpGet("by-Race_EventStatus/{upcoming}")]

        [AllowAnonymous]
        public async Task<IActionResult> GetUpcomingEvents(string upcoming)
        {
            var isUpcoming = await _dbcontext.race_Events
                .AsNoTracking()
                .Where(e => e.Race_EventStatus == upcoming)
                .Select(e => new
                {
                    e.Race_EventId,
                    e.Race_EventName,
                    e.Race_EventDate,
                    e.Description,
                    e.Race_EventStatus
                }).ToListAsync();


            return Ok(isUpcoming);
        }
       
        [HttpPost]
        public IActionResult AddNewEvent(Race_EventDTO eventDTO)
        {
            var newEvent = new Race_Event
            {
                VenueId = eventDTO.VenueId,
                Race_EventName = eventDTO.Race_EventName,
                Race_EventDate = eventDTO.Race_EventDate,
                Description = eventDTO.Description,
                Race_EventStatus = eventDTO.Race_EventStatus
            };
            _dbcontext.race_Events.Add(newEvent);
            _dbcontext.SaveChanges();
            return Ok("New event added successfully");
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEvent(int id, Race_EventDTO eventDTO)
        {
            var existingEvent = _dbcontext.race_Events.Find(id);
            if (existingEvent == null) return NotFound($"No event was found with ID {id}");
            existingEvent.VenueId = eventDTO.VenueId;
            existingEvent.Race_EventName = eventDTO.Race_EventName;
            existingEvent.Race_EventDate = eventDTO.Race_EventDate;
            existingEvent.Description = eventDTO.Description;
            existingEvent.Race_EventStatus = eventDTO.Race_EventStatus;
            _dbcontext.SaveChanges();
            return Ok("Event updated successfully");
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEvent(Guid id)
        {
            var existingEvent = _dbcontext.race_Events.Find(id);
            if (existingEvent == null) return NotFound($"No event was found with ID {id}");
            _dbcontext.race_Events.Remove(existingEvent);
            _dbcontext.SaveChanges();
            return Ok("Event deleted successfully");
        }
    }
}
