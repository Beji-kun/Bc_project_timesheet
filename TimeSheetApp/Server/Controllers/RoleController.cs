using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Server.Services.Interfaces;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _roleService;
        public RoleController(IRole roleService)
        {
            _roleService = roleService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Role>>> GetAllRoles()
        {
            return Ok(await _roleService.GetAllRoles());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int? id)
        {
            Role role = await _roleService.GetRoleByID(id);

            if (role == null)
            {
                return NotFound($"Role with Id {id} doesn't exit");
            }

            return Ok(role);
        }


        [HttpGet("GetLastRoleId")]
        public int GetLastRoleId()
        {
            return _roleService.GetLastRoleId();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role newRole)
        {
            Role createRole = await _roleService.CreateRole(newRole);

            if (createRole != null)
            {
                return new CreatedAtActionResult("GetRole", "Role", new { createRole.ID }, createRole);
            }
            else
            {
                return BadRequest("Error occured please try again.");
            }
        }

        [HttpPost]
        public IActionResult UpdateRole([FromBody] Role role)
        {
            _roleService.UpdateRole(role);

            return Ok("Role updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            string result = await _roleService.DeleteRole(id);

            if (result == null)
            {
                return BadRequest("Role doesn't exit");
            }

            return Ok("Role deleted successfully");
        }

    }
}
