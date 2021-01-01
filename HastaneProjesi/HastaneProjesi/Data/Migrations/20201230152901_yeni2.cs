using Microsoft.EntityFrameworkCore.Migrations;

namespace HastaneProjesi.Data.Migrations
{
    public partial class yeni2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aa5cad07-afb1-48d5-86be-b09d3634b5a1", "9a41410e-c254-478c-83a4-7c90865c375e", "user", null },
                    { "e17291ae-2332-4977-a6bf-e5d6b3bcf356", "e5058c06-6e93-4db8-88a6-819d00b3314c", "admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SurName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c342b369-ccd2-4648-b187-10c5c655bbb5", 0, "2b47a270-2410-42b1-ad1b-b564966cd6b0", null, false, true, null, "Muhammet", null, "B191210304@SAKARYA.EDU.TR", "AQAAAAEAACcQAAAAEEhgfwI70dzvoYp2RTjqqfw60wbI6kbGq9rQ/uiZPc6RRFwz9uUQmrBHcKjeuwpz4A==", null, false, "RNMOTMWYZL6PRE362MLDKMO2QTCRNLIB", "Sağlam", false, "b191210304@sakarya.edu.tr" },
                    { "36035f22-9c94-42bd-8282-8e2b019b2fd1", 0, "d8e84a25-0ff2-425c-8cc0-c6ed76b60d21", null, false, true, null, "Numan", null, "B191210307@SAKARYA.EDU.TR", "AQAAAAEAACcQAAAAEEHoQ0ViyBmp3yPvMsGBVSrLUiubppv3DnUDJHHp7RnyYwULnf9W5dEiACxRfQVcFA==", null, false, "ST4AAWGZ5UA2RSQGVBI6BHW5JO7JZQYW", "Güngör", false, "b191210307@sakarya.edu.tr" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator" },
                values: new object[] { "c342b369-ccd2-4648-b187-10c5c655bbb5", "e17291ae-2332-4977-a6bf-e5d6b3bcf356", "UserRol" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Discriminator" },
                values: new object[] { "36035f22-9c94-42bd-8282-8e2b019b2fd1", "e17291ae-2332-4977-a6bf-e5d6b3bcf356", "UserRol" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa5cad07-afb1-48d5-86be-b09d3634b5a1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "36035f22-9c94-42bd-8282-8e2b019b2fd1", "e17291ae-2332-4977-a6bf-e5d6b3bcf356" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "c342b369-ccd2-4648-b187-10c5c655bbb5", "e17291ae-2332-4977-a6bf-e5d6b3bcf356" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e17291ae-2332-4977-a6bf-e5d6b3bcf356");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "36035f22-9c94-42bd-8282-8e2b019b2fd1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c342b369-ccd2-4648-b187-10c5c655bbb5");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");
        }
    }
}
