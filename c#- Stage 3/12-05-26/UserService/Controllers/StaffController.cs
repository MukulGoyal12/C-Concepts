using Microsoft.AspNetCore.Mvc;
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

        // GET: api/<StaffController>
        [HttpGet]
        public IEnumerable<Staff> Get()
        {
            return _context.Staffs.ToList();
        }

        // GET api/<StaffController>/5
        [HttpGet("{id}")]
        public Staff Get(int id)
        {
            return _context.Staffs.Find(id);
        }

        // POST api/<StaffController>
        [HttpPost]
        public void Post([FromBody] Staff staff)
        {
            _context.Staffs.Add(staff);
            _context.SaveChanges();
        }

        // PUT api/<StaffController>/5
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
