using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleService.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="varchar(40)")]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string Model { get; set; }
        [Required]
        [Column(TypeName = "varchar(15)")]
        public string RegnNo { get; set; }
        public int EngnieCapacity { get; set; }
         public int Year { get; set; } = 0;
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string CreatedBy { get; set; } //email of the user who created the vehicle record
    }
}
