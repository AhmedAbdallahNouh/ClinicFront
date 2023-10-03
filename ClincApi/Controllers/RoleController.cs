using ClinicModels.DTOs.MainDTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult> getAllRoles()
        {
            List<IdentityRole> roles = await roleManager.Roles.ToListAsync();
            List<RoleDTO> roleDTOs = new List<RoleDTO>();

            return roles.Count != 0 ?  Ok(roles) : NotFound("user hase no roles");
          
        }

        [HttpPost]
        public async Task<ActionResult> Add(string? Name)
        {
            if (Name == null)
            {
                ModelState.AddModelError("Name", "Name is required");
                return BadRequest();
            }
            IdentityRole role = new IdentityRole(Name);
            IdentityResult result = await roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return Ok(role);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return BadRequest();
        }
    }
}
