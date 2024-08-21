using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace P_Asignación_de_Tareas.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    idComment = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    descriptionCommet = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.idComment);
                });

            migrationBuilder.CreateTable(
                name: "module",
                columns: table => new
                {
                    IdMod = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameMod = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.IdMod);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    idNotification = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nameNotification = table.Column<string>(type: "text", nullable: false),
                    descriptionNotification = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.idNotification);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    idTask = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nameTask = table.Column<string>(type: "text", nullable: false),
                    descriptionTask = table.Column<string>(type: "text", nullable: false),
                    dateTask = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dateTaskCompletion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.idTask);
                });

            migrationBuilder.CreateTable(
                name: "operation_rol",
                columns: table => new
                {
                    IdOperationsRol = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameOperationRol = table.Column<string>(type: "text", nullable: false),
                    IdModulo = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation_rol", x => x.IdOperationsRol);
                    table.ForeignKey(
                        name: "FK_operation_rol_module",
                        column: x => x.IdModulo,
                        principalTable: "module",
                        principalColumn: "IdMod");
                }); 

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    password = table.Column<int>(type: "integer", nullable: false),
                    emailUser = table.Column<string>(type: "text", nullable: true),
                    nameUser = table.Column<string>(type: "text", nullable: true),
                    IdRol = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_users_rol_RolIdRol",
                        column: x => x.IdRol,
                        principalTable: "rol",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "proyects",
                columns: table => new
                {
                    idProyect = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idTasks = table.Column<int>(type: "integer", nullable: false),
                    nameProyect = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyects", x => x.idProyect);
                    table.ForeignKey(
                        name: "FK_proyects_tasks_TasksidTask",
                        column: x => x.idTasks,
                        principalTable: "tasks",
                        principalColumn: "idTask");
                });

            migrationBuilder.CreateTable(
                name: "operaciones",
                columns: table => new
                {
                    IdRolpOperation = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdRol = table.Column<int>(type: "integer", nullable: false),
                    IdOperaciones = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operaciones", x => x.IdRolpOperation);
                    table.ForeignKey(
                        name: "FK_operaciones_operation_rol_Operations_IdOperaciones",
                        column: x => x.IdOperaciones,
                        principalTable: "operation_rol",
                        principalColumn: "IdOperationsRol");
                    table.ForeignKey(
                        name: "FK_operaciones_rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "rol",
                        principalColumn: "IdRol");
                });

            migrationBuilder.CreateTable(
                name: "auxiliarT",
                columns: table => new
                {
                    idAuxiliar = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idUser = table.Column<int>(type: "integer", nullable: false),
                    idProyect = table.Column<int>(type: "integer", nullable: false),
                    idCommet = table.Column<int>(type: "integer", nullable: false),
                    idNotification = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auxiliarT", x => x.idAuxiliar);
                    table.ForeignKey(
                        name: "FK_auxiliarT_comments_idCommet",
                        column: x => x.idCommet,
                        principalTable: "comments",
                        principalColumn: "idComment");
                    table.ForeignKey(
                        name: "FK_auxiliarT_notifications_idNotification",
                        column: x => x.idNotification,
                        principalTable: "notifications",
                        principalColumn: "idNotification");
                    table.ForeignKey(
                        name: "FK_auxiliarT_proyects_idProyect",
                        column: x => x.idProyect,
                        principalTable: "proyects",
                        principalColumn: "idProyect");
                    table.ForeignKey(
                        name: "FK_auxiliarT_users_idUser",
                        column: x => x.idUser,
                        principalTable: "users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_idCommet",
                table: "auxiliarT",
                column: "idCommet");

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_idNotification",
                table: "auxiliarT",
                column: "idNotification");

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_idProyect",
                table: "auxiliarT",
                column: "idProyect");

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_idUser",
                table: "auxiliarT",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_operaciones_Operations_IdOperaciones",
                table: "operaciones",
                column: "IdOperaciones");

            migrationBuilder.CreateIndex(
                name: "IX_operaciones_IdRol",
                table: "operaciones",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_operation_rol_IdModulo",
                table: "operation_rol",
                column: "IdModulo");

            migrationBuilder.CreateIndex(
                name: "IX_proyects_idTasks",
                table: "proyects",
                column: "idTasks");

            migrationBuilder.CreateIndex(
                name: "IX_users_IdRol",
                table: "users",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auxiliarT");

            migrationBuilder.DropTable(
                name: "operaciones");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "proyects");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "operation_rol");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "module");
        }
    }
}
