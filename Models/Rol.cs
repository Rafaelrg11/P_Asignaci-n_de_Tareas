using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P_Asignación_de_Tareas.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol {  get; set; }
        public string nombre { get; set; }
        public virtual ICollection<Users> Users { get; set; } = new List<Users>();
        public virtual ICollection<OperationsXd> Operacion { get; set; } = new List<OperationsXd>();
    }
}
