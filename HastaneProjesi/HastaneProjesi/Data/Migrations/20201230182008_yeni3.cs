using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneProjesi.Data.Migrations
{
    public partial class yeni3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa5cad07-afb1-48d5-86be-b09d3634b5a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e17291ae-2332-4977-a6bf-e5d6b3bcf356",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b815f8ca-442b-4b81-8f8e-73d5ba2a2271", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c25676d8-829e-41cb-8a7f-af3d177c8fca", "5282ce18-8d92-4464-864c-b0687afbe92e", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c25676d8-829e-41cb-8a7f-af3d177c8fca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e17291ae-2332-4977-a6bf-e5d6b3bcf356",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e5058c06-6e93-4db8-88a6-819d00b3314c", "admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "aa5cad07-afb1-48d5-86be-b09d3634b5a1", "9a41410e-c254-478c-83a4-7c90865c375e", "user", null });
        }
    }
}
