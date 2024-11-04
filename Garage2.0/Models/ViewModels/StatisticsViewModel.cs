﻿using Garage2._0.Models.Entities;
using System.ComponentModel;

namespace Garage2._0.Models.ViewModels
{
    public class StatisticsViewModel
    {
        public int Id { get; set; }
        public VehicleType Type { get; set; }
        public string? Color { get; set; }

        public string? Brand { get; set; }
        public int Wheel { get; set; }

        public string? Model { get; set; }
    }
}
