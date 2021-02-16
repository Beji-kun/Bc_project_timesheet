using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Server.Interfaces;
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
        public IActionResult GetAllRoles()
        {
            List<Role> allRoles = _roleService.GetAllRoles();

            if (allRoles.Count == 0)
            {
                return BadRequest("No role exit, try creating a new role");
            }

            return Ok(allRoles);
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


        [HttpGet("GetLastAccountId")]
        public int GetLastAccountId()
        {
            return _roleService.GetLastRoleId();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Role newRole)
        {
            Role createdAccount = await _roleService.CreateRole(newRole);

            if (createdAccount != null)
            {
                return new CreatedAtActionResult("GetRole", "Role", new { createdAccount.ID }, createdAccount);
            }
            else
            {
                return BadRequest("Error occured please try again.");
            }
        }

        [HttpPost]
        public IActionResult UpdateAccount([FromBody] Role account)
        {
            _roleService.UpdateRole(account);

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
