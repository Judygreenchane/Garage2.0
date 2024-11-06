﻿using Garage2._0.Data;
using Garage2._0.Validation;
using System.ComponentModel.DataAnnotations;

namespace Garage2._0.Models.Entities
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        [Required]
        public VehicleType VehicleType { get; set; }
        [Required]
        [RegularExpression(@"^[A-Za-z]{3}[0-9]{3}$", ErrorMessage = "Registration number must follow the format ABC123.")]
        [UniqueRegistrationNumber(typeof(Garage2_0Context), ErrorMessage = "Registration number must be unique.")]

        public string? RegistrationNumber { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The field must be between 2 and 20 characters long.")]
        public string? Color { get; set; }
        [StringLength(20, MinimumLength = 2, ErrorMessage = "The field must be between 2 and 20 characters long.")]
        public string? Brand { get; set; }
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The field must be between 1 and 20 characters long.")]
        public string? VehicleModel { get; set; }
        [Range(0, 100, ErrorMessage = "It must be a non-negative number.")]
        public int Wheel { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
