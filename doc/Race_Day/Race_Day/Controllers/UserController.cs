using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Data;
using Race_Day.Models;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;

namespace Race_Day.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly ApplicationDbcontext dbcontext;
        public UserController(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var Users = dbcontext.accounts.ToList();
            return Ok(Users);
        }
        [HttpGet]
        [Route("{id:guid}")]

        public IActionResult GetUserByID(Guid id)
        {
            var User = dbcontext.accounts.Find(id);
            if (User == null) return NotFound();
            return Ok(User);
        }
        [HttpPost]
        public IActionResult AddNewUser(CreateUser addDTO)
        {
            var user = new UserAccount
            {
                UserAccountName = addDTO.Name,
                UserAccountEmail = addDTO.Email,
                UserAccountPassword = addDTO.Password,
                UserAccountRole     = addDTO.Role,
                UserAccountPhone = addDTO.Phone,
                
            };

            dbcontext.accounts.Add(user);
            dbcontext.SaveChanges();
            return Ok("User was added successfully");
        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult EditUserPorfile(Guid id, UpdateUser editDTO)
        {
            var user = dbcontext.accounts.Find(id);
            if (user == null) return NotFound($"No user was found with {id}");
            if (editDTO.Name != null) user.UserAccountName = editDTO.Name      ;
            if (editDTO.Email != null) user.UserAccountEmail = editDTO.Email;
            if (editDTO.Phone != null) user.UserAccountPhone = editDTO.Phone; 
            if (editDTO.Role != null) user.UserAccountRole = editDTO.Role;


            dbcontext.SaveChanges();
            return Ok("User profile updated.");

        }
        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult RemoveUser(Guid id)
        {
        var User = dbcontext.accounts.Find(id);
            if (User == null) return NotFound($"No user was found with {id}");

            dbcontext.accounts.Remove(User);
            dbcontext.SaveChanges();
            return Ok("User was Deleted successfully");
        }
    }
}
