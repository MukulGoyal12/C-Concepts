namespace MaintenanceService.Data.DTOs
{
    public class MaintenanceScheduleInsert
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string RegnNo { get; set; }
        public int EngnieCapacity { get; set; }
        public int Year { get; set; } = 0;
        public DateTime ScheduledDate { get; set; }= DateTime.Now;
        public string MaintenanceType { get; set; }
    }
}
