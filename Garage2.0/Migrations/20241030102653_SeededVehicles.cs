using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Garage2._0.Migrations
{
    /// <inheritdoc />
    public partial class SeededVehicles : Migration 
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "RegistrationNumber", "VehicleModel", "VehicleType", "Wheel" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 8, 18, 7, 22, 15, 0, DateTimeKind.Unspecified), "Benz", "Blue", "ERT987", "280s", 0, 4 },
                    { 2, new DateTime(2012, 7, 19, 8, 29, 23, 0, DateTimeKind.Unspecified), "Volvo", "Red", "KDR536", "142", 0, 4 },
                    { 3, new DateTime(2011, 5, 23, 9, 42, 17, 0, DateTimeKind.Unspecified), "Honda", "Green", "LDT432", "CGI", 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
