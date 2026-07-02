namespace MaintenanceTypeService.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class MaintenanceType
    {
        public int Id { get; set; }
     
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public string Frequency { get; set; }
        public int KM { get; set; }

    }
}
