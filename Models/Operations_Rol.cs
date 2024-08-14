using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P_Asignación_de_Tareas.Models
{
    public class Operations_Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOperationsRol { get; set; }
        public string NameOperationRol { get; set; }
        public int IdModulo { get; set; }
        public virtual ICollection<Operations> Operaciones { get; set; } = new List<Operations>();
    }
}
