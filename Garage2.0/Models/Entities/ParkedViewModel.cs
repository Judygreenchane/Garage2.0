using System.ComponentModel;

namespace Garage2._0.Models.Entities
{
    public class ParkedViewModel
    {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
