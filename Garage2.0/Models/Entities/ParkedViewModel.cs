namespace Garage2._0.Models.Entities
{
    public class ParkedViewModel
    {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string RegistrationNumber { get; set; }
        public TimeOnly ArrivalTime { get; set; }
    }
}
