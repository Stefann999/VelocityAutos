using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocityAutos.Data.Migrations
{
    public partial class AddUserFirstNameAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Test");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "User");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPa7fMT+y/ZHs1GyEd0kQ9xS53uVZDrHNLOh/4vWtQ8x7zwB3e16URlliDcDEwpYbg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAED+J21/TogJKnNZTfz/QoujvINS+2TNIlvXJzDRqp9xIm7eBm6+7B5EhuvqwRszskA==");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 18, 33, 3, 246, DateTimeKind.Utc).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 18, 33, 3, 246, DateTimeKind.Utc).AddTicks(8964));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEF2uKoSPlboH2Tr25B0+3+YAQ8orlud6w61Z2rWNCF5J7McyhHrzGBZJHk6IHBtxeQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEI7W3viLgOvu6vhA0CHgG0Kcs/rZmPV9gafxWLR3cqOnuzTMFCPLzM6pFW6Z6OGoGA==");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                column: "CreatedOn",
                value: new DateTime(2024, 2, 23, 20, 14, 24, 765, DateTimeKind.Utc).AddTicks(3284));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                column: "CreatedOn",
                value: new DateTime(2024, 2, 18, 20, 14, 24, 765, DateTimeKind.Utc).AddTicks(3271));
        }
    }
}
