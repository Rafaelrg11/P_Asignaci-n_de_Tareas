using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P_Asignación_de_Tareas.Migrations
{
    /// <inheritdoc />
    public partial class stateUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "proyects");

            migrationBuilder.AddColumn<string>(
                name: "state",
                table: "tasks",
                type: "character varying",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "state",
                table: "tasks");

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "proyects",
                type: "character varying",
                nullable: false,
                defaultValue: "");
        }
    }
}
