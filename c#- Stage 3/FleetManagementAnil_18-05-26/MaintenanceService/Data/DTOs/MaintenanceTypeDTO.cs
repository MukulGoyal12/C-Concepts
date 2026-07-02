using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceService.Data.DTOs
{
    public class MaintenanceTypeDTO
    {
 
        public string Name { get; set; }
 
        public string VehicleType { get; set; }
 
        public string Description { get; set; } = string.Empty;
 
        public string Frequency { get; set; }
        public int KM { get; set; }
    }
}
