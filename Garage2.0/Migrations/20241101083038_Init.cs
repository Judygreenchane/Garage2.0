﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Garage2._0.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VehicleModel = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Wheel = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkedVehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkedVehicle",
                columns: new[] { "Id", "ArrivalTime", "Brand", "Color", "RegistrationNumber", "VehicleModel", "VehicleType", "Wheel" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 8, 18, 7, 22, 15, 0, DateTimeKind.Unspecified), "Benz", "Blue", "ERT987", "280s", 3, 4 },
                    { 2, new DateTime(2012, 7, 19, 8, 29, 23, 0, DateTimeKind.Unspecified), "Volvo", "Red", "KDR536", "142", 3, 4 },
                    { 3, new DateTime(2011, 5, 23, 9, 42, 17, 0, DateTimeKind.Unspecified), "Honda", "Green", "LDT432", "CGI", 4, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkedVehicle");
        }
    }
}
