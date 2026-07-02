using System.Security.Claims;
using EFCore.BulkExtensions;
using MaintenanceService.Data.DTOs;
using MaintenanceService.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleService.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaintenanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        MaintenaceDbContext _context;
        public MaintenanceController(MaintenaceDbContext context)
        {
            _context = context;
        }
        // Compiled query for better performance when fetching schedules by type
        public static readonly Func<MaintenaceDbContext,string,IEnumerable<MaintenanceSchedule>> GetSchedulesByTypeQuery =
            EF.CompileQuery(( MaintenaceDbContext context,  string type) =>
                context.MaintenanceSchedules.Where(m => m.Type == type));

        // GET: api/<MaintenanceController>
        [HttpGet]
        public IEnumerable<MaintenanceSchedule> Get()
        {
            return _context.MaintenanceSchedules;
        }

        // GET api/<MaintenanceController>/5
        [HttpGet("{id}")]
        public MaintenanceSchedule Get(int id)
        {
            return _context.MaintenanceSchedules.FirstOrDefault(m => m.Id == id);
        }
        [HttpGet]
        [Route("getSchedulesByType/{type}")]
        public IEnumerable<MaintenanceSchedule> GetSchedulesByType(string type)
        {
            return GetSchedulesByTypeQuery(_context, type);
        }

        // POST api/<MaintenanceController>
        [HttpPost]
        [Route("createSchedule")]
      
        public IActionResult Post([FromBody] List<MaintenanceScheduleInsert> schedules)
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            List<MaintenanceSchedule> entities = new List<MaintenanceSchedule>();
            foreach (var schedule in schedules)
            {
                var entity = new MaintenanceSchedule
                {
                        Type = schedule.Type,
                        Model = schedule.Model,
                        RegnNo = schedule.RegnNo,
                        EngnieCapacity = schedule.EngnieCapacity,
                        Year = schedule.Year,
                        ScheduledDate = schedule.ScheduledDate,
                        MaintenanceType = schedule.MaintenanceType,
                        CreatedBy = "anil@gmail.com"
                };
                    entities.Add(entity);
                }
                _context.MaintenanceSchedules.AddRange(entities);
            //or use the bulk insert for better performance
            //_context.BulkInsert(entities);
                _context.SaveChanges();
            
            return Ok(schedules); 
        }
        [HttpPost]
        [Route("generateSchedule")]
  
        public IActionResult GenerateSchedule([FromBody] VehicleDTO vehicle)
        {
            var maintenanceTypes = _context.MaintenanceTypes.Where(mc => mc.VehicleType == vehicle.Type).ToList();
            // Simple logic to generate a maintenance schedule based on vehicle type and engine capacity
            var schedules = new List<MaintenanceSchedule>();
            foreach (var maintenanceType in maintenanceTypes)
            {
                    schedules.Add( new MaintenanceSchedule
                    {
                        Type = vehicle.Type,
                        Model = vehicle.Model,
                        RegnNo = vehicle.RegnNo,
                        EngnieCapacity = vehicle.EngnieCapacity,
                        Year = vehicle.Year,
                        ScheduledDate = DateTime.Now.AddMonths(6), // Schedule for 6 months later
                        MaintenanceType = maintenanceType.Name,
                        CreatedBy = "anil@gmail.com"
                        // CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "email" || c.Type == ClaimTypes.Email || c.Type == System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub)?.Value
                    });
            }
            _context.BulkInsert(schedules);
            return Ok(schedules);
        }

        // PUT api/<MaintenanceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MaintenanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
