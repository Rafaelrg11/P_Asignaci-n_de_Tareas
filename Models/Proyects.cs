using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P_Asignación_de_Tareas.Models
{
    public class Proyects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProyect { get; set; }
        public int idTasks { get; set; }
        public string nameProyect { get; set; }
        public virtual Tasks Task { get; set; }
        public virtual ICollection<AuxiliarT> AuxiliarT { get; set; } = new List<AuxiliarT>(); 
    }
}
