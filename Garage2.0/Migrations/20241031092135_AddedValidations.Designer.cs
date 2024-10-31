﻿// <auto-generated />
using System;
using Garage2._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage2._0.Migrations
{
    [DbContext(typeof(Garage2_0Context))]
    [Migration("20241031092135_AddedValidations")]
    partial class AddedValidations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Garage2._0.Models.Entities.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Color")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleModel")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.Property<int>("Wheel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkedVehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalTime = new DateTime(2018, 8, 18, 7, 22, 15, 0, DateTimeKind.Unspecified),
                            Brand = "Benz",
                            Color = "Blue",
                            RegistrationNumber = "ERT987",
                            VehicleModel = "280s",
                            VehicleType = 0,
                            Wheel = 4
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new DateTime(2012, 7, 19, 8, 29, 23, 0, DateTimeKind.Unspecified),
                            Brand = "Volvo",
                            Color = "Red",
                            RegistrationNumber = "KDR536",
                            VehicleModel = "142",
                            VehicleType = 0,
                            Wheel = 4
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new DateTime(2011, 5, 23, 9, 42, 17, 0, DateTimeKind.Unspecified),
                            Brand = "Honda",
                            Color = "Green",
                            RegistrationNumber = "LDT432",
                            VehicleModel = "CGI",
                            VehicleType = 1,
                            Wheel = 2
                        });
                });

            modelBuilder.Entity("Garage2._0.Models.Entities.ParkedViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkedViewModel");
                });
#pragma warning restore 612, 618
        }
    }
}
