using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocityAutos.Data.Migrations
{
    public partial class ChangeDbArchitecture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKVcYxror+hRee5TXgjCW20F3EuC3dAHzwfWh8fRdCCJOn+xaD643bQsArC81KPgHg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEHNzsj5Hcd4rM1HZUbhPUBu5regOekrb6Hm+bOuZ8gA6q23tZ4bOgQQ5jJrj0xnG3g==");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFlyeXYKAUMYGcW3xGznEPcu6uE59yKvpkZ0zQ3ji3pFLzwjCxnTbPZ8au4Fs3TzSg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEPfcF5zHPD351m7SCLhj/CX8dHPORF7M6AvIbazlmk+P3//GHUYZ95ldIl4lX5HqHQ==");
        }
    }
}
