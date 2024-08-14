using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P_Asignación_de_Tareas.Models
{
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMod {  get; set; }
        public string NameMod { get; set; }
        public virtual ICollection<Operations_Rol> OperationsRol { get; set; } = new List<Operations_Rol>();
    }
}
