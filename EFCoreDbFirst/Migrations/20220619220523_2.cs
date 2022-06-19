using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDbFirst.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TaskItem",
                type: "INTEGER",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TaskItem",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TaskItem");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TaskItem");
        }
    }
}
