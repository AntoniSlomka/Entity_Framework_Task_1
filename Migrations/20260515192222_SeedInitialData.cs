using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCodeFirstTask1.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "NVIDIA", new DateTime(1993, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "NVIDIA Corporation" },
                    { 2, "Intel", new DateTime(1968, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Corporation" },
                    { 3, "AMD", new DateTime(1969, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced Micro Devices, Inc." },
                    { 4, "Samsung", new DateTime(1969, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samsung Electronics Co., Ltd." }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "RAM", "Random Access Memory" },
                    { 2, "CPU", "Central Proccesing Unit" },
                    { 3, "GPU", "Graphics Proccesing Unit" },
                    { 4, "SSD", "Solid State Drive" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "UltraDesk Pro", 12, 24, 8.5f },
                    { 2, new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GamerRig X", 7, 12, 11.2f },
                    { 3, new DateTime(2022, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "WorkStation Z", 3, 36, 14f },
                    { 4, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CompactMini 500", 20, 12, 3.8f }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturerId", "ComponentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { "990PRO2T", 4, 4, "PCIe 4.0 NVMe SSD with sequential read up to 7450 MB/s.", "Samsung 990 Pro 2 TB NVMe" },
                    { "DDR532G", 4, 1, "Single 32 GB DDR5 DIMM running at 6000 MT/s.", "Samsung 32 GB DDR5-6000" },
                    { "R75800X", 3, 2, "8-core, 16-thread desktop processor with 3.8 GHz base clock.", "AMD Ryzen 7 5800X" },
                    { "RTX4090", 1, 3, "Ada Lovelace flagship GPU with 24 GB GDDR6X VRAM.", "NVIDIA GeForce RTX 4090" }
                });

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PCId", "Amount" },
                values: new object[,]
                {
                    { "DDR532G", 1, 2 },
                    { "R75800X", 1, 1 },
                    { "990PRO2T", 2, 2 },
                    { "RTX4090", 2, 1 },
                    { "990PRO2T", 3, 4 },
                    { "R75800X", 3, 1 },
                    { "DDR532G", 4, 1 },
                    { "RTX4090", 4, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "DDR532G", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "R75800X", 1 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "990PRO2T", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "RTX4090", 2 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "990PRO2T", 3 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "R75800X", 3 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "DDR532G", 4 });

            migrationBuilder.DeleteData(
                table: "PCComponents",
                keyColumns: new[] { "ComponentCode", "PCId" },
                keyValues: new object[] { "RTX4090", 4 });

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "990PRO2T");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "DDR532G");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "R75800X");

            migrationBuilder.DeleteData(
                table: "Components",
                keyColumn: "Code",
                keyValue: "RTX4090");

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PCs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentManufacturers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ComponentTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
