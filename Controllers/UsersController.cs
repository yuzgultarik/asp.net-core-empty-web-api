using core_tarik_api_empty.Data;
using core_tarik_api_empty.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace core_tarik_api_empty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        #region rafinin yazdıkları
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        #endregion

        // id numarasına göre eleman getirme metodu
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserDetail(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();

            }
            return user;
        }


        [HttpPost("createUser")]
        public async Task<IActionResult> PostUserDetail(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //var deleteuser  = await _context.Users.FindAsync(id);

            //deleteuser = _context.Users.Find(x => x.id == id);
            var deleteuser = _context.Users.FirstOrDefault(x => x.id == id);
            if (deleteuser == null) {
                return NotFound();
            }

            _context.Remove(deleteuser);
            await _context.SaveChangesAsync();
            return Ok();
        }


    }
}
