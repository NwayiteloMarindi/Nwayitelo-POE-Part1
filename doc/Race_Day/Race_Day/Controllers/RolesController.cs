using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public readonly ApplicationDbcontext dbcontext;
        public RolesController(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public IActionResult GetAllRoles() {
            var roles = dbcontext.Roles.ToList();

            return Ok(roles);
        }
        [HttpPost]
        public IActionResult AddNewRole(NewRoleDTO nrDTO)
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
        public IActionResult UpdateRole(Guid id, UpdateRole urDTO)
        {
            var role = dbcontext.Roles.Find(id);
            if (role == null) return NotFound($"No role was found with {id}");
            if (urDTO.Role != null) role.RoleName = urDTO.Role;
            if (urDTO.Email != null) role.RoleDescription = urDTO.Email;
            dbcontext.SaveChanges();
            return Ok("Role was updated successfully");
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRole(Guid id)
        {
            var role = dbcontext.Roles.Find(id);
            if (role == null) return NotFound($"No role was found with {id}");
            dbcontext.Roles.Remove(role);
            dbcontext.SaveChanges();
            return Ok("Role was deleted successfully");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AssignRoleToUser(Guid userId, Guid roleId)
        {
            var user = dbcontext.users.Find(userId);
            var role = dbcontext.Roles.Find(roleId);
            if (user == null || role == null)
            {
                return NotFound("User or Role not found.");
            }
            user.Role = role.RoleName; // Assuming the User entity has a Role property
            dbcontext.SaveChanges();
            return Ok($"Role '{role.RoleName}' assigned to user '{user.Name}'.");
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult RemoveRoleFromUser(Guid userId)
        {
            var user = dbcontext.users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            user.Role = null; // Assuming the User entity has a Role property
            dbcontext.SaveChanges();
            return Ok($"Role removed from user '{user.Name}'.");
        }

    }
}
