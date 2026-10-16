using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Data;
using Race_Day.Models.DTO;

namespace Race_Day.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly ApplicationDbcontext dbcontext;
        public ResultsController(ApplicationDbcontext dbcontext)
        {
         this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllResults()
        {
            var results = dbcontext.results
             .Select(r => $"Result {r.ResultsId}: {r.ResultsPosition} at {r.ResultsTime}")
            .ToList();
            return Ok(results);
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetResultById(int id)
        {
            var result = dbcontext.results.Find(id);
            if (result == null) return NotFound($"No result was found with ID {id}");
            return Ok($"Result {result.ResultsId}: {result.ResultsPosition} at {result.ResultsTime}");
        }
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateResult(int id, UpdateResultsDTO updatedResult)
        {
            var result = dbcontext.results.Find(id);
            if (result == null) return NotFound($"No result was found with ID {id}");
            result.ResultsName = updatedResult.ResultsName ?? result.ResultsName;
            result.ResultsPosition = updatedResult.ResultsPosition ?? result.ResultsPosition;
            result.ResultsTime = updatedResult.ResultsTime ?? result.ResultsTime;
            result.ResultsStatus = updatedResult.ResultsStatus ?? result.ResultsStatus;
            dbcontext.SaveChanges();
            return Ok($"Result {result.ResultsId} was updated successfully");
        }
        [HttpGet]
        public IActionResult GetResultsByRegistrationId(int registrationId)
        {
            var results = dbcontext.results
                .Where(r => r.RegistrationId == registrationId)
                .Select(r => $"Result {r.ResultsId}: {r.ResultsPosition} at {r.ResultsTime}")
                .ToList();
            if (!results.Any()) return NotFound($"No results were found for Registration ID {registrationId}");
            return Ok(results);
        }
    }
}
