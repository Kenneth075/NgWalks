﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NgWalks.Api.Data;

#nullable disable

namespace NgWalks.Api.Migrations
{
    [DbContext(typeof(NgWalksDbContext))]
    [Migration("20240814142725_Seeding Migration")]
    partial class SeedingMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NgWalks.Api.Models.Domain.Difficulty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("53588cb0-2b1b-42a0-a45a-488e3791fc00"),
                            Name = "Easy"
                        },
                        new
                        {
                            Id = new Guid("ba089749-2153-4b78-abda-9ee2611c8db7"),
                            Name = "Medium"
                        },
                        new
                        {
                            Id = new Guid("296bf176-a66f-4f86-b806-0535af9a5de4"),
                            Name = "Hard"
                        });
                });

            modelBuilder.Entity("NgWalks.Api.Models.Domain.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8ad9b8c9-a00f-480d-a9a1-a57fee37e79a"),
                            Code = "AKS",
                            Name = "Akwa Ibom",
                            RegionImageUrl = "AkwaIbom.Aks.jpg"
                        },
                        new
                        {
                            Id = new Guid("5bc41d79-4617-40d9-801d-e321f7b44675"),
                            Code = "RIV",
                            Name = "Rivers",
                            RegionImageUrl = "Rivers.RIV.jpg"
                        },
                        new
                        {
                            Id = new Guid("85a0cd50-abad-4896-9e0c-8beace050a18"),
                            Code = "BAY",
                            Name = "Bayelsa",
                            RegionImageUrl = "Bayelsa.BAY.jpg"
                        },
                        new
                        {
                            Id = new Guid("24b413a1-85b9-4abd-8d52-d41c0aec202a"),
                            Code = "LAG",
                            Name = "Lagos",
                            RegionImageUrl = ""
                        },
                        new
                        {
                            Id = new Guid("382c02d4-70ed-4392-8c23-3f6d3086aeab"),
                            Code = "ABI",
                            Name = "Abia",
                            RegionImageUrl = ""
                        });
                });

            modelBuilder.Entity("NgWalks.Api.Models.Domain.Walk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DifficultyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("LengthInKm")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegionalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("WalkImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("RegionId");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("NgWalks.Api.Models.Domain.Walk", b =>
                {
                    b.HasOne("NgWalks.Api.Models.Domain.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NgWalks.Api.Models.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Difficulty");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
