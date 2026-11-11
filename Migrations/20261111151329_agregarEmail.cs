using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace M12_NotasEf.Migrations
{
    /// <inheritdoc />
    public partial class agregarEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Estudiantes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Estudiantes");
        }
    }
}
