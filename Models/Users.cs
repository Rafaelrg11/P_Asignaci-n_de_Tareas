using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P_Asignación_de_Tareas.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUser { get; set; }
        public int password { get; set; }
        public string? emailUser { get; set; }
        public string? nameUser { get; set; }
        public int IdRol { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<Notifications> Notification { get; set; } = new List<Notifications>();
        public virtual ICollection<AuxiliarT> AuxiliarT { get; set; } = new List<AuxiliarT>();
    }
}
