using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace P_Asignación_de_Tareas.Models
{
    public class ApplicationDbcontext : DbContext
    {

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
            : base(options) { }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Proyects> Proyects { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<AuxiliarT> AuxiliarTs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("users");
            modelBuilder.Entity<Proyects>().ToTable("proyects");
            modelBuilder.Entity<Tasks>().ToTable("tasks");
            modelBuilder.Entity<Notifications>().ToTable("notifications");
            modelBuilder.Entity<Comments>().ToTable("comments");
            modelBuilder.Entity<AuxiliarT>().ToTable("auxiliarT");
        }
    }
}
