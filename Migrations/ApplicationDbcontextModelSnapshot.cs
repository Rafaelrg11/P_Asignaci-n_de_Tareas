﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using P_Asignación_de_Tareas.Models;

#nullable disable

namespace P_Asignación_de_Tareas.Migrations
{
    [DbContext(typeof(ApplicationDbcontext))]
    partial class ApplicationDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.AuxiliarT", b =>
                {
                    b.Property<int>("idAuxiliar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idAuxiliar"));

                    b.Property<int?>("CommentsidComment")
                        .HasColumnType("integer");

                    b.Property<int?>("NotificationsidNotification")
                        .HasColumnType("integer");

                    b.Property<int?>("ProyectsidProyect")
                        .HasColumnType("integer");

                    b.Property<int?>("UsersidUser")
                        .HasColumnType("integer");

                    b.Property<int>("idCommet")
                        .HasColumnType("integer");

                    b.Property<int>("idNotification")
                        .HasColumnType("integer");

                    b.Property<int>("idProyect")
                        .HasColumnType("integer");

                    b.Property<int>("idUser")
                        .HasColumnType("integer");

                    b.HasKey("idAuxiliar");

                    b.HasIndex("CommentsidComment");

                    b.HasIndex("NotificationsidNotification");

                    b.HasIndex("ProyectsidProyect");

                    b.HasIndex("UsersidUser");

                    b.ToTable("auxiliarT", (string)null);
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Comments", b =>
                {
                    b.Property<int>("idComment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idComment"));

                    b.Property<string>("descriptionCommet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idComment");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Notifications", b =>
                {
                    b.Property<int>("idNotification")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idNotification"));

                    b.Property<string>("descriptionNotification")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nameNotification")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idNotification");

                    b.ToTable("notifications", (string)null);
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Proyects", b =>
                {
                    b.Property<int>("idProyect")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idProyect"));

                    b.Property<int>("idTasks")
                        .HasColumnType("integer");

                    b.Property<string>("nameProyect")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("idProyect");

                    b.ToTable("proyects", (string)null);
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Tasks", b =>
                {
                    b.Property<int>("idTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idTask"));

                    b.Property<DateTime>("dateTask")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("dateTaskCompletion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("descriptionTask")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nameTask")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("proyectsidProyect")
                        .HasColumnType("integer");

                    b.HasKey("idTask");

                    b.HasIndex("proyectsidProyect");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Users", b =>
                {
                    b.Property<int>("idUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("idUser"));

                    b.Property<string>("emailUser")
                        .HasColumnType("text");

                    b.Property<string>("nameUser")
                        .HasColumnType("text");

                    b.Property<int>("password")
                        .HasColumnType("integer");

                    b.HasKey("idUser");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.AuxiliarT", b =>
                {
                    b.HasOne("P_Asignación_de_Tareas.Models.Comments", null)
                        .WithMany("AuxiliarT")
                        .HasForeignKey("CommentsidComment");

                    b.HasOne("P_Asignación_de_Tareas.Models.Notifications", null)
                        .WithMany("AuxiliarT")
                        .HasForeignKey("NotificationsidNotification");

                    b.HasOne("P_Asignación_de_Tareas.Models.Proyects", null)
                        .WithMany("AuxiliarT")
                        .HasForeignKey("ProyectsidProyect");

                    b.HasOne("P_Asignación_de_Tareas.Models.Users", null)
                        .WithMany("AuxiliarT")
                        .HasForeignKey("UsersidUser");
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Tasks", b =>
                {
                    b.HasOne("P_Asignación_de_Tareas.Models.Proyects", "proyects")
                        .WithMany("Tasks")
                        .HasForeignKey("proyectsidProyect")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("proyects");
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Comments", b =>
                {
                    b.Navigation("AuxiliarT");
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Notifications", b =>
                {
                    b.Navigation("AuxiliarT");
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Proyects", b =>
                {
                    b.Navigation("AuxiliarT");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("P_Asignación_de_Tareas.Models.Users", b =>
                {
                    b.Navigation("AuxiliarT");
                });
#pragma warning restore 612, 618
        }
    }
}
