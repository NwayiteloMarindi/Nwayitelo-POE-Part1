using Microsoft.AspNetCore.Mvc;
using Race_Day.Client.Models.DTOs;

namespace Race_Day.Mvc.Controllers
{
    
    public class EventController : Controller
    {
        public readonly ILogger<EventController> _logger;
        public readonly IHttpClientFactory _factory;
        public EventController(ILogger<EventController> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }
        
        public async Task<IActionResult> Index()
        {
            var client = _factory.CreateClient("ApiClient");
            var events = await client.GetFromJsonAsync<List<EventDto>>(
           "/api/Event");
            var today = DateOnly.FromDateTime(DateTime.Now);
            var model = new DashboardDto
            {
               
                EventCount = events.Count,
                
                AllEvents = events,
                UpcomingEvents = events.Where(e => e.Race_EventStatus == "Upcoming" && e.Race_EventDate >today).ToList(),
            };

          

            return View(model);
        }

       // public async Task<IActionResult> Create() { }

    }
}