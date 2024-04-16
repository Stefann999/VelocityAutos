using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocityAutos.Data.Migrations
{

    public partial class SeedMoreCarsAndPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAECubMiU9A3OjpeFxmeC4PKqJ/G0pQgiXr6jFsQ9/kZB/sRI6SZ/pyIGdfF0lZLCJog==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80821bfc-806b-4ae5-b279-b931e1afc048"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENZf9tAO1hkqQCcDQRRspvGHLXH5u3rP9HFf+CHx27cBCT3vFkzyMInUAdw0m1OU4w==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEO9nt+lakqye8sZmmAZQaDR0TXC/fvfNDgIDxtFMG5Y6EdFfigV7t7ANiayREvvxTQ==");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "Description", "FuelConsumption", "FuelTypeId", "HorsePower", "LocationCity", "LocationCountry", "Make", "Mileage", "Model", "Month", "Price", "TransmissionTypeId", "Year" },
                values: new object[,]
                {
                    { new Guid("82f03f75-cfb3-4434-bb73-f8c5dcf4109d"), 2, "Graphite", "The Hyundai i40 offers a blend of comfort, performance, and technology in the midsize sedan segment. With its spacious interior, efficient engines, and modern features, the i40 delivers a refined driving experience suitable for both urban commutes and long highway journeys.", 8.0, 2, 136, "Blagoevgrad", "Bulgaria", "Hyundai", 179000, "I40", 9, 22000m, 2, 2015 },
                    { new Guid("c48b7dcd-0d04-4a56-bfe0-df00eb6812b5"), 2, "White", "The new Porsche GT3 RS is a track-focused powerhouse, featuring a high-revving naturally aspirated engine and lightweight construction for agile handling. With aerodynamic enhancements and over 500 horsepower on tap, it promises an exhilarating driving experience that's both thrilling on the track and rewarding on the road.", 13.5, 1, 525, "Sofia", "Bulgaria", "Porsche", 100, "911 GT3 RS", 1, 280000m, 2, 2024 },
                    { new Guid("f6707b62-64e1-415f-af35-eb635f988c47"), 3, "Black", "Beautiful compact hatchback. The car combines fuel efficiency with practicality, boasting a sleek design and responsive handling. Its hybrid powertrain offers a smooth driving experience while minimizing environmental impact, making it an ideal choice for eco-conscious drivers.", 6.0, 4, 100, "Plovdiv", "Bulgaria", "Toyota", 68000, "Yaris", 4, 27000m, 2, 2019 },
                    { new Guid("fd1f3b19-7e3b-4fec-a1b0-e47188884a42"), 4, "Black", "The BMW X5 epitomizes luxury and versatility in the midsize SUV segment, offering a spacious cabin, cutting-edge technology, and robust performance. With its refined interior, smooth ride, and impressive array of features, the X5 is designed to provide comfort and excitement for both daily driving and adventurous journeys alike.", 12.0, 2, 381, "Varna", "Bulgaria", "BMW", 200000, "X5", 2, 49999m, 2, 2014 }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                columns: new[] { "CreatedOn", "SellerFirstName", "SellerLastName" },
                values: new object[] { new DateTime(2024, 4, 1, 17, 52, 45, 588, DateTimeKind.Utc).AddTicks(3154), "Dimitur", "Vasilev" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                columns: new[] { "CreatedOn", "SellerFirstName", "SellerLastName" },
                values: new object[] { new DateTime(2024, 3, 27, 17, 52, 45, 588, DateTimeKind.Utc).AddTicks(3144), "Ivan", "Stoilov" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CarId", "CreatedOn", "DeletedOn", "IsActive", "SellerEmailAddress", "SellerFirstName", "SellerId", "SellerLastName", "SellerPhoneNumber", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("042963e9-c983-4253-ad5b-c5a75c894dd8"), new Guid("c48b7dcd-0d04-4a56-bfe0-df00eb6812b5"), new DateTime(2024, 3, 29, 17, 52, 45, 588, DateTimeKind.Utc).AddTicks(3159), null, true, "dimitur122@cars.com", "Dimitur", new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"), "Vasilev", "0813819279", null },
                    { new Guid("7af043e6-1324-4a7a-89ac-45a02945d6a1"), new Guid("f6707b62-64e1-415f-af35-eb635f988c47"), new DateTime(2024, 4, 15, 17, 52, 45, 588, DateTimeKind.Utc).AddTicks(3162), null, true, "ivancars1@cars.com", "Ivan", new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"), "Stoilov", "0867219923", null },
                    { new Guid("e050004c-40e3-4edc-95ef-72beff4b2377"), new Guid("82f03f75-cfb3-4434-bb73-f8c5dcf4109d"), new DateTime(2024, 3, 23, 17, 52, 45, 588, DateTimeKind.Utc).AddTicks(3167), null, true, "ivancars1@cars.com", "Ivan", new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"), "Stoilov", "0867219923", null },
                    { new Guid("f37270cc-5251-4255-add7-f837b01e6453"), new Guid("fd1f3b19-7e3b-4fec-a1b0-e47188884a42"), new DateTime(2024, 3, 29, 17, 52, 45, 588, DateTimeKind.Utc).AddTicks(3170), null, true, "dimitur122@cars.com", "Dimitur", new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"), "Vasilev", "0813819279", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("042963e9-c983-4253-ad5b-c5a75c894dd8"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7af043e6-1324-4a7a-89ac-45a02945d6a1"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e050004c-40e3-4edc-95ef-72beff4b2377"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f37270cc-5251-4255-add7-f837b01e6453"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("82f03f75-cfb3-4434-bb73-f8c5dcf4109d"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c48b7dcd-0d04-4a56-bfe0-df00eb6812b5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f6707b62-64e1-415f-af35-eb635f988c47"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("fd1f3b19-7e3b-4fec-a1b0-e47188884a42"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENJAPswQiPAfmDASilbDO/aVF+Xx773ZXSW24OxaHlg+8uMQnSYcka1bjKge5xTz3Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80821bfc-806b-4ae5-b279-b931e1afc048"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJnM9NaJ1jZTzNo7+l6MYSp3Ou4BxrVyvGBhxzGWeWqJEyQF18Ftt7leLonyfeEHww==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGtq30tAx0BGffkdifb9rH4ffY6Q6mn9ggPYjrixF4Uq2zyAa29Kiep8jjDjY0Y4pw==");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                columns: new[] { "CreatedOn", "SellerFirstName", "SellerLastName" },
                values: new object[] { new DateTime(2024, 3, 23, 13, 32, 53, 45, DateTimeKind.Utc).AddTicks(4724), "Ivan", "Stoilov" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                columns: new[] { "CreatedOn", "SellerFirstName", "SellerLastName" },
                values: new object[] { new DateTime(2024, 3, 18, 13, 32, 53, 45, DateTimeKind.Utc).AddTicks(4712), "Dimitur", "Vasilev" });
        }
    }
}
