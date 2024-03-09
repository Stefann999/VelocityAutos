using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocityAutos.Data.Migrations
{
    public partial class AddAttributesToPostEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerPhoneNumber",
                table: "Posts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SellerLastName",
                table: "Posts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SellerFirstName",
                table: "Posts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerPhoneNumber",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "SellerLastName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "SellerFirstName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEDRd6vIbIsvycW5haJSLkgLfponB1qC/4rbLR/EWuKwuVm1nbMx64JjeeSWK8C2EEg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFnTW5mfnaQrbOOtB6WwroIYffF/k/QmymoQAGhlg2oB9MPBNE3pFwSwd7qPESWxgg==");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                column: "CreatedOn",
                value: new DateTime(2024, 2, 21, 20, 32, 42, 679, DateTimeKind.Utc).AddTicks(4937));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                column: "CreatedOn",
                value: new DateTime(2024, 2, 16, 20, 32, 42, 679, DateTimeKind.Utc).AddTicks(4922));
        }
    }
}
