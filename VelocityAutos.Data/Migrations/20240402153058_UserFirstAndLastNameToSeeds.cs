using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VelocityAutos.Data.Migrations
{
    public partial class UserFirstAndLastNameToSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                columns: new[] { "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "Ivan", "Stoilov", "AQAAAAEAACcQAAAAEAf9BwHgltdLnVHPQ4RZ5g58D15y/Bz9N2MavvG7m+p433SrZZoJrAus5EM6+pARZQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                columns: new[] { "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "Dimitur", "Vasilev", "AQAAAAEAACcQAAAAEOqBIuwdC+k8zDi+YBTN3ner6pROY+yQtcIcjZrhfQZCAVcrS+MHTykkfCEsnShmoA==" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                columns: new[] { "CreatedOn", "SellerLastName" },
                values: new object[] { new DateTime(2024, 3, 18, 15, 30, 57, 600, DateTimeKind.Utc).AddTicks(6156), "Stoilov" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 13, 15, 30, 57, 600, DateTimeKind.Utc).AddTicks(6141));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66543f29-bafc-4680-8028-5c4b7e444ccb"),
                columns: new[] { "FirstName", "LastName", "PasswordHash" },
                values: new object[] { null, null, "AQAAAAEAACcQAAAAEBte1prmMkm9+bA2xmFzxb6sOhbQW2w4ROVTB2fXe295TTUwHs23h9zclo6k8Z+sdQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed670787-a2d5-45e9-a069-83dcd8e84e30"),
                columns: new[] { "FirstName", "LastName", "PasswordHash" },
                values: new object[] { null, null, "AQAAAAEAACcQAAAAEJtjq91MqSkpDrLCNGyy7DncrSUHoxChMOFllpU9KxAO6Mrz/14QyEJZ8r1iRnuLZA==" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("3e5e72c8-ae7d-4c68-ad81-1bdc9c9eaad9"),
                columns: new[] { "CreatedOn", "SellerLastName" },
                values: new object[] { new DateTime(2024, 3, 9, 19, 4, 22, 961, DateTimeKind.Utc).AddTicks(3023), "Zdravkov" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("b5a2fe5f-8161-48d4-bd61-0d6f1b38609c"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 4, 19, 4, 22, 961, DateTimeKind.Utc).AddTicks(3014));
        }
    }
}
