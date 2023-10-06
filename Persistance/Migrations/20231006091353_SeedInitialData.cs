using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("96ae491d-ab67-489c-ab00-8eb57d05f11a"), "96ae491d-ab67-489c-ab00-8eb57d05f11a", "Admin", "Admin" },
                    { new Guid("f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b"), "f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b", "User", "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"), 0, "9ff62f67-66ca-4b14-a6ba-ebb702622f55", "luka@o2.pl", false, false, null, "LUKA@O2.PL", "LUKA", "AQAAAAIAAYagAAAAEMOj0BePleN5IlkgzyoLWmO4Y0IWuTMHyn0R8t3YDMkGgxGKE98TC51HNGOIZ4PsFQ==", null, false, null, false, "Luka" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("96ae491d-ab67-489c-ab00-8eb57d05f11a"), new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be") },
                    { new Guid("f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b"), new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("96ae491d-ab67-489c-ab00-8eb57d05f11a"), new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b"), new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("96ae491d-ab67-489c-ab00-8eb57d05f11a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f27601ac-d6e3-43a7-ad7d-acf5bfc41b7b"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19e3d4bf-37f2-4ed6-8ae3-8c6eae9920be"));
        }
    }
}
