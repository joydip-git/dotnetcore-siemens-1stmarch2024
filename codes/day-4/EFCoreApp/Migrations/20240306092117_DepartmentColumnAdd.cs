using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentColumnAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "emp_dept",
                table: "employeeinfos",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "emp_dept",
                table: "employeeinfos");
        }
    }
}
