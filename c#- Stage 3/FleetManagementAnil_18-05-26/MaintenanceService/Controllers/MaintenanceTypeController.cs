using MaintenanceService.Data.DTOs;
using MaintenanceService.Data.Models;
using MaintenanceTypeService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaintenanceService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceTypeController : ControllerBase
    {
        MaintenaceDbContext _context;
        public MaintenanceTypeController(MaintenaceDbContext context)
        {
            _context = context;
        }
        // GET: api/<MaintenanceTypeController>
        [HttpGet]
        public IEnumerable<MaintenanceType> Get()
        {
            return _context.MaintenanceTypes.ToList();
        }

        // GET api/<MaintenanceTypeController>/5
        [HttpGet("{vehicleType}")]
        public List<MaintenanceType> Get(string vehicleType)
        {
            return _context.MaintenanceTypes.Where(mt => mt.VehicleType == vehicleType).ToList();
        }

        // POST api/<MaintenanceTypeController>
        [HttpPost]
        public void Post([FromBody] MaintenanceTypeDTO value)
        {
            var entity = new MaintenanceType
            {
                Name = value.Name,
                VehicleType = value.VehicleType,
                Description = value.Description,
                Frequency = value.Frequency,
                KM = value.KM
            };
            _context.MaintenanceTypes.Add(entity);
            _context.SaveChanges();
        }
 
    }
}
