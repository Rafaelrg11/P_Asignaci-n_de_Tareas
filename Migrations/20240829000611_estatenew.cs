using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_Asignación_de_Tareas.Migrations
{
    /// <inheritdoc />
    public partial class estatenew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "proyects",
                type: "character varying",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "proyects");
        }
    }
}
