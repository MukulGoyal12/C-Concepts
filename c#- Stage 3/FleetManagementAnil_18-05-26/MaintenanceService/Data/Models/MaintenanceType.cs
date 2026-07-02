using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceTypeService.Models
{
    public class MaintenanceType
    {

        [Key]
        [Column(TypeName = "varchar(40)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string VehicleType { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public string Frequency { get; set; }
        public int KM { get; set; }

    }
}
