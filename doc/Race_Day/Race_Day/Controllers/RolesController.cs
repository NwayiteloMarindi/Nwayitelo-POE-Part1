using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Race_Day.Data;
using Race_Day.Models.DTO;
using Race_Day.Models.Entities;

namespace Race_Day.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbcontext dbcontext;

        public RolesController(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

       
        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = dbcontext.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost]
        public IActionResult AddNewRole([FromBody] NewRoleDTO nrDTO)
        {
            var newRole = new Roles
            {
                RoleName = nrDTO.RoleName,
                RoleDescription = nrDTO.RoleDescription
            };
            dbcontext.Roles.Add(newRole);
            dbcontext.SaveChanges();
            return Ok("Role was added successfully");
        }

      
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateRole(Guid id, [FromBody] UpdateRole urDTO)
        {
            var role = dbcontext.Roles.Find(id);
            if (role == null) return NotFound($"No role was found with {id}");

            if (!string.IsNullOrWhiteSpace(urDTO.Role))
                role.RoleName = urDTO.Role;

          

            dbcontext.SaveChanges();
            return Ok("Role was updated successfully");
        }

      
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRole(Guid id)
        {
            var role = dbcontext.Roles.Find(id);
            if (role == null) return NotFound($"No role was found with {id}");

            dbcontext.Roles.Remove(role);
            dbcontext.SaveChanges();
            return Ok("Role was deleted successfully");
        }

        
        [HttpPost("assign")]
        [Authorize(Roles = "Admin")]
        public IActionResult AssignRoleToUser([FromBody] AssignRoleDTO dto)
        {
            var user = dbcontext.accounts.Find(dto.UserId);
            var role = dbcontext.Roles.Find(dto.RoleId);

            if (user == null || role == null)
                return NotFound("User or Role not found.");

            user.UserAccountRole = role.RoleName;
            dbcontext.SaveChanges();

            return Ok($"Role '{role.RoleName}' assigned to user '{user.UserAccountName}'.");
        }

        // ─────────────────────────────────────────────
        // DELETE api/Roles/assign/{userId}
        // ─────────────────────────────────────────────
        [HttpDelete("assign/{userId:guid}")]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveRoleFromUser(Guid userId)
        {
            var user = dbcontext.accounts.Find(userId);
            if (user == null) return NotFound("User not found.");

            user.UserAccountRole = null;
            dbcontext.SaveChanges();

            return Ok($"Role removed from user '{user.UserAccountName}'.");
        }
    }

    // ── DTOs (add these if you don't already have them) ──
    public class AssignRoleDTO
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}