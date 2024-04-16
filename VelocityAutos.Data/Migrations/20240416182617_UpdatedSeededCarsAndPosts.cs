using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocityAutos.Data.Migrations
{
    public partial class UpdatedSeededCarsAndPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG7Rt2hHRNvywTGxF0oXMhf4vfXhEjC1+fBygdo6ViAPwiYA4tx/4aurqeu3OtfcIg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80821bfc-806b-4ae5-b279-b931e1afc048"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEN/8aefgN2U5wgJs9Axpx/uK4aWWPG7m5nJKcz8zHvEMp6uhFe4HkeILBPpdc54VtA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEGTc0CSoYocFoefOMY+49E1y7Zc8exnHFtuGCjBsk7Q0Ml4W42iLORit3RYrI/C0YA==");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f6707b62-64e1-415f-af35-eb635f988c47"),
                column: "Description",
                value: "Beautiful compact sedan. The car combines fuel efficiency with practicality, boasting a sleek design and responsive handling. Its hybrid powertrain offers a smooth driving experience while minimizing environmental impact, making it an ideal choice for eco-conscious drivers.");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("042963e9-c983-4253-ad5b-c5a75c894dd8"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 29, 18, 26, 16, 808, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 1, 18, 26, 16, 808, DateTimeKind.Utc).AddTicks(4113));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7af043e6-1324-4a7a-89ac-45a02945d6a1"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 15, 18, 26, 16, 808, DateTimeKind.Utc).AddTicks(4118));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 27, 18, 26, 16, 808, DateTimeKind.Utc).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e050004c-40e3-4edc-95ef-72beff4b2377"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 18, 26, 16, 808, DateTimeKind.Utc).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f37270cc-5251-4255-add7-f837b01e6453"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 29, 18, 26, 16, 808, DateTimeKind.Utc).AddTicks(4125));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHJhb59dyUbk69jdhfBcYtBjQp5t0UYUSLC/z66PYMs5M4O7Xmpbcu6mjIyR21XkCQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("80821bfc-806b-4ae5-b279-b931e1afc048"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFUPYRRfvGPDsvWUcxQTfeSkY1Btpm8v8Xwbe1TcwzpkQnRay6ZLQhwoYxzGcXn2AA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIokRRsQ2TVdgpz4T4MA1anooBZF5YLuV9VPdMhO+s/v+AUGv4vZ6UeCQmZRYKQgkA==");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f6707b62-64e1-415f-af35-eb635f988c47"),
                column: "Description",
                value: "Beautiful compact hatchback. The car combines fuel efficiency with practicality, boasting a sleek design and responsive handling. Its hybrid powertrain offers a smooth driving experience while minimizing environmental impact, making it an ideal choice for eco-conscious drivers.");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("042963e9-c983-4253-ad5b-c5a75c894dd8"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 29, 18, 15, 13, 457, DateTimeKind.Utc).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 1, 18, 15, 13, 457, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("7af043e6-1324-4a7a-89ac-45a02945d6a1"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 15, 18, 15, 13, 457, DateTimeKind.Utc).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 27, 18, 15, 13, 457, DateTimeKind.Utc).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e050004c-40e3-4edc-95ef-72beff4b2377"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 23, 18, 15, 13, 457, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f37270cc-5251-4255-add7-f837b01e6453"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 29, 18, 15, 13, 457, DateTimeKind.Utc).AddTicks(3115));
        }
    }
}
