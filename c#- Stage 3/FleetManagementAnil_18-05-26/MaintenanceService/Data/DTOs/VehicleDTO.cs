namespace VehicleService.Models
{
    public class VehicleDTO
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string RegnNo { get; set; }
        public int EngnieCapacity { get; set; }
        public int Year { get; set; } = 0;
    }
}
