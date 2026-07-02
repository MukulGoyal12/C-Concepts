namespace MaintenanceService.Data.Models
{
    public class MaintenanceSchedule
    {
        public int Id { get; set; }
        public string Type { get; set; }//vehicle
        public string Model { get; set; }//vehilce
        public string RegnNo { get; set; }//vehicle
        public int EngnieCapacity { get; set; }//vehicle
        public int Year { get; set; } = 0;//vehicle
        public DateTime ScheduledDate { get; set; } //find based maintenance type master
        public string MaintenanceType { get; set; }//find based maintenance type master
        public string CreatedBy { get; set; } //email of the user who created the maintenance schedule record - token

    }
}
