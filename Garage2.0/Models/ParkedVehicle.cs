﻿namespace Garage2._0.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string RegistrationNumber { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string VehicleModel { get; set; }
        public int Wheel { get; set; }
        public DateTime ArrivalTime { get; set; }

    }
}
