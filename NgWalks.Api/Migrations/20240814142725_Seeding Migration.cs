using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NgWalks.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("296bf176-a66f-4f86-b806-0535af9a5de4"), "Hard" },
                    { new Guid("53588cb0-2b1b-42a0-a45a-488e3791fc00"), "Easy" },
                    { new Guid("ba089749-2153-4b78-abda-9ee2611c8db7"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("24b413a1-85b9-4abd-8d52-d41c0aec202a"), "LAG", "Lagos", "" },
                    { new Guid("382c02d4-70ed-4392-8c23-3f6d3086aeab"), "ABI", "Abia", "" },
                    { new Guid("5bc41d79-4617-40d9-801d-e321f7b44675"), "RIV", "Rivers", "Rivers.RIV.jpg" },
                    { new Guid("85a0cd50-abad-4896-9e0c-8beace050a18"), "BAY", "Bayelsa", "Bayelsa.BAY.jpg" },
                    { new Guid("8ad9b8c9-a00f-480d-a9a1-a57fee37e79a"), "AKS", "Akwa Ibom", "AkwaIbom.Aks.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("296bf176-a66f-4f86-b806-0535af9a5de4"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("53588cb0-2b1b-42a0-a45a-488e3791fc00"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ba089749-2153-4b78-abda-9ee2611c8db7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("24b413a1-85b9-4abd-8d52-d41c0aec202a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("382c02d4-70ed-4392-8c23-3f6d3086aeab"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5bc41d79-4617-40d9-801d-e321f7b44675"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("85a0cd50-abad-4896-9e0c-8beace050a18"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8ad9b8c9-a00f-480d-a9a1-a57fee37e79a"));
        }
    }
}
