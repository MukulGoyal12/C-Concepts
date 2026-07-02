using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StaffService.Helpers;
using StaffService.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StaffService.Controllers
{
    
    [ApiController]
    public class StaffController : ControllerBase
    {
        StaffContext context;
        public StaffController(StaffContext ctx)
        {
                context = ctx;
        }
        [HttpGet]
        [Route("staff")]
        public IActionResult Get()
        {
            return Ok(context.Staffs.ToList());
        }
        [HttpPost]
        
        [Route("staff/register")]
        public void Post([FromBody] Staff value)
        {
            context.Staffs.Add(value);
            context.SaveChanges();
        }
        
        [HttpPost]
        [Route("staff/login")]
        public IActionResult Validate([FromBody] LoginModel login)
        {
          var found =  context.Staffs.Where(s=> s.Email == login.Email && s.Password == login.Password).FirstOrDefault();
            if(found!=null)
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

        // PUT api/<StaffController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Staff value)
        {
                        var staff = context.Staffs.Find(id);
            if (staff != null)
            {
                staff.Name = value.Name;
                staff.Position = value.Position;
                staff.Password=value.Password;
                context.SaveChanges();
            }
        }

       
    }
}
