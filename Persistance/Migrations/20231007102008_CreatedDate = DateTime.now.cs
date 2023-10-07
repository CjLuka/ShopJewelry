using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDateDateTimenow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "64afbee9-c51e-40fc-ae1d-ccf10dd5de76", "AQAAAAIAAYagAAAAEIe+913ELJ0KOfRO361Y58jNxKutcrz8ovie7ozkZFtUQoSPp78SqwVYwlYwkfk9eg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ff62f67-66ca-4b14-a6ba-ebb702622f55", "AQAAAAIAAYagAAAAEMOj0BePleN5IlkgzyoLWmO4Y0IWuTMHyn0R8t3YDMkGgxGKE98TC51HNGOIZ4PsFQ==" });
        }
    }
}
