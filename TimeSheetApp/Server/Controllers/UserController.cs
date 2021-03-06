﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Server.Data;
using TimeSheetApp.Server.Services.Interfaces;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        public UserController(IUser userService)
        {
            _userService = userService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(int? id)
        {
            User user = await _userService.GetUserByID(id);

            if (user == null)
            {
                return NotFound($"User with Id {id} doesn't exit");
            }

            return Ok(user);
        }


        [HttpGet("GetLastRoleId")]
        public int GetLastRoleId()
        {
            return _userService.GetLastUserId();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User newUser)
        {
            User createUser = await _userService.CreateUser(newUser);

            if (createUser != null)
            {
                return new CreatedAtActionResult("GetUser", "User", new { createUser.ID }, createUser);
            }
            else
            {
                return BadRequest("Error occured please try again.");
            }
        }

        [HttpPost]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);

            return Ok("User updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            string result = await _userService.DeleteUser(id);

            if (result == null)
            {
                return BadRequest("User doesn't exit");
            }

            return Ok("User deleted successfully");
        }

    }
}