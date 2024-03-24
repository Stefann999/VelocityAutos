using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocityAutos.Data.Migrations
{
    public partial class ChangeEmailAdressToNonNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerEmailAddress",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBte1prmMkm9+bA2xmFzxb6sOhbQW2w4ROVTB2fXe295TTUwHs23h9zclo6k8Z+sdQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEJtjq91MqSkpDrLCNGyy7DncrSUHoxChMOFllpU9KxAO6Mrz/14QyEJZ8r1iRnuLZA==");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 19, 4, 22, 961, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 19, 4, 22, 961, DateTimeKind.Utc).AddTicks(3014));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerEmailAddress",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
