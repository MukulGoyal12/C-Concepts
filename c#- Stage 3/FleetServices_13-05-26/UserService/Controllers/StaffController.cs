using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffService.Helpers;
using StaffService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {

        StaffContext _context;
        public StaffController(StaffContext ctx)
        {
            _context = ctx;
        }

        [HttpPost]
        [Route("register")]
        public void Post([FromBody] Staff staff)
        {
            _context.Staffs.Add(staff);
            _context.SaveChanges();
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Validate([FromBody] LoginModel login)
        {
            var found = _context.Staffs.Where(s => s.Email == login.Email && s.Password == login.Password).FirstOrDefault();
            if (found != null)
            {
                var token = JWTHelper.GenerateToken(found);
                TokenMessage result = new TokenMessage { Status = "Success", Token = token };
                return Ok(result);
            }
            else
            {
                return NotFound(new TokenMessage { Status = "Failed", Token = string.Empty });
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Staff value)
        {
            Staff staff = _context.Staffs.Find(id);
            if (staff != null)
            {
                staff.Name = value.Name;
                staff.Email = value.Email;
                staff.Position = value.Position;
                staff.Password = value.Password;
                _context.SaveChanges();
            }
        }

    }
}
