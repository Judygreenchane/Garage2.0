using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Models;
using Humanizer.Localisation;
using Garage2._0.Models.Entities;

namespace Garage2._0.Data
{
    public class Garage2_0Context : DbContext
    {
        public Garage2_0Context (DbContextOptions<Garage2_0Context> options)
            : base(options)
        {
        }

        public DbSet<Garage2._0.Models.Entities.ParkedVehicle> ParkedVehicle { get; set; } = default!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParkedVehicle>().HasData(
             new ParkedVehicle { Id = 1, VehicleType = VehicleType.Car, RegistrationNumber = "ERT987", Color = "Blue", Brand = "Benz", VehicleModel = "280s", Wheel = 4, ArrivalTime = DateTime.Parse("08/18/2018 07:22:15") },
             new ParkedVehicle { Id = 2, VehicleType = VehicleType.Car, RegistrationNumber = "KDR536", Color = "Red", Brand = "Volvo", VehicleModel = "142", Wheel = 4, ArrivalTime = DateTime.Parse("07/19/2012 08:29:23") },
             new ParkedVehicle { Id = 3, VehicleType = VehicleType.Motorcycle, RegistrationNumber = "LDT432", Color = "Green", Brand = "Honda", VehicleModel = "CGI", Wheel = 2, ArrivalTime = DateTime.Parse("05/23/2011 09:42:17") }

                );
        }

    }
}
