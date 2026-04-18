using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateYearEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumberCustom",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumberCustom",
                table: "AspNetUsers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
