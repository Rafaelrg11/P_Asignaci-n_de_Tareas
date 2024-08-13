using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace P_Asignación_de_Tareas.Migrations
{
    public partial class InitDB : Migration
    {
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
                name: "proyects",
                columns: table => new
                {
                    idProyect = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idTasks = table.Column<int>(type: "integer", nullable: false),
                    nameProyect = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyects", x => x.idProyect);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    password = table.Column<int>(type: "integer", nullable: false),
                    emailUser = table.Column<string>(type: "text", nullable: true),
                    nameUser = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.idUser);
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
                    dateTaskCompletion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    proyectsidProyect = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.idTask);
                    table.ForeignKey(
                        name: "FK_tasks_proyects_proyectsidProyect",
                        column: x => x.proyectsidProyect,
                        principalTable: "proyects",
                        principalColumn: "idProyect",
                        onDelete: ReferentialAction.Cascade);
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
                    CommentsidComment = table.Column<int>(type: "integer", nullable: true),
                    NotificationsidNotification = table.Column<int>(type: "integer", nullable: true),
                    ProyectsidProyect = table.Column<int>(type: "integer", nullable: true),
                    UsersidUser = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_auxiliarT", x => x.idAuxiliar);
                    table.ForeignKey(
                        name: "FK_auxiliarT_comments_CommentsidComment",
                        column: x => x.CommentsidComment,
                        principalTable: "comments",
                        principalColumn: "idComment");
                    table.ForeignKey(
                        name: "FK_auxiliarT_notifications_NotificationsidNotification",
                        column: x => x.NotificationsidNotification,
                        principalTable: "notifications",
                        principalColumn: "idNotification");
                    table.ForeignKey(
                        name: "FK_auxiliarT_proyects_ProyectsidProyect",
                        column: x => x.ProyectsidProyect,
                        principalTable: "proyects",
                        principalColumn: "idProyect");
                    table.ForeignKey(
                        name: "FK_auxiliarT_users_UsersidUser",
                        column: x => x.UsersidUser,
                        principalTable: "users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_CommentsidComment",
                table: "auxiliarT",
                column: "CommentsidComment");

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_NotificationsidNotification",
                table: "auxiliarT",
                column: "NotificationsidNotification");

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_ProyectsidProyect",
                table: "auxiliarT",
                column: "ProyectsidProyect");

            migrationBuilder.CreateIndex(
                name: "IX_auxiliarT_UsersidUser",
                table: "auxiliarT",
                column: "UsersidUser");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_proyectsidProyect",
                table: "tasks",
                column: "proyectsidProyect");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "auxiliarT");

            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "proyects");
        }
    }
}
