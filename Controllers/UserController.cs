using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserProject.Models;
using UserProject.Models.Interfaces;
using UserProject.Models.Services;

namespace UserProject.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserService userService;

        public UserController(AppDbContext appDbContext)
        {
            _context = appDbContext;
            userService = new UserService(appDbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var allUsers = await userService.GetAll();

            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            var user = await userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser([FromBody]UserModel user)
        {
            await userService.Add(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody]UserModel user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await userService.Update(id, user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}