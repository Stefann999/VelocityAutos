using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocityAutos.Data.Migrations
{
    public partial class SeedUsersAndCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"), 0, "668e7d82-3497-47eb-9098-6132d4888d53", "ivancars1@cars.com", true, false, null, "IVANCARS1@CARS.COM", "IVANCARS1@CARS.COM", "AQAAAAEAACcQAAAAEEslbS1ssyu9KGqaJjrV7cxoa0X3t3wUZlLMpPVBf/I6AUwuvtzUx+fuoJihKXrkAw==", "0888888888", true, "f49c695d-b65c-4245-a204-70ac1ef3167c", false, "ivancars1@cars.com" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"), 0, "3f509880-8a4c-4e64-ba38-353c1611c646", "dimitur122@cars.com", true, false, null, "DIMITUR122@CARS.COM", "DIMITUR122@CARS.COM", "AQAAAAEAACcQAAAAENCLjbLySmw+HGu7oLpvB2g5L+TTjAauK1VhQdIN65awCRiPvbE75b7hVTdrL8mKXg==", "0999999999", true, "e5507714-6b85-407b-a9e4-85b8856de4bd", false, "dimitur122@cars.com" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "FuelConsumption", "FuelTypeId", "HorsePower", "LocationCity", "LocationCountry", "Make", "Mileage", "Model", "Month", "OwnerId", "Price", "TransmissionTypeId", "Year", "isSold" },
                values: new object[] { new Guid("74576f3e-a409-46e4-a8ff-9c93eb409cba"), 1, "Black", "The 2019 Audi A4 is a luxury compact sedan that combines sophisticated design, advanced technology, and impressive performance.", 6.5, 1, 150, "Sofia", "Bulgaria", "Audi", 10000, "A4", 3, new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"), 50000m, 1, 2019, false });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "FuelConsumption", "FuelTypeId", "HorsePower", "LocationCity", "LocationCountry", "Make", "Mileage", "Model", "Month", "OwnerId", "Price", "TransmissionTypeId", "Year", "isSold" },
                values: new object[] { new Guid("9219e817-e86a-4ea0-807f-976d8195d93a"), 2, "White", "The Mercedes-AMG GT 63 S is a high-performance luxury four-door coupe that offers a combination of striking design, advanced technology, and powerful performance.", 15.0, 1, 639, "Sofia", "Bulgaria", "Mercedes", 5000, "GT63 S 4-door", 1, new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"), 200000m, 2, 2023, false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("74576f3e-a409-46e4-a8ff-9c93eb409cba"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9219e817-e86a-4ea0-807f-976d8195d93a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"));
        }
    }
}
