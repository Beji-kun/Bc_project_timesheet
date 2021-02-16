using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Server.Data;
using TimeSheetApp.Shared.Entities;

namespace TimeSheetApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usr = await _context.Users.ToListAsync();
            return Ok(usr);
        }
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usr = await _context.Users.FirstOrDefaultAsync(a => a.ID == id);
            return Ok(usr);
        }
        //create
        [HttpPost]
        public async Task<IActionResult> Post(User usr)
        {
            _context.Add(usr);
            await _context.SaveChangesAsync();
            return Ok(usr.ID);
        }
        //update
        [HttpPut]
        public async Task<IActionResult> Put(User usr)
        {
            _context.Entry(usr).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usr = new User { ID = id };
            _context.Remove(usr);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}