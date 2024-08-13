using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P_Asignación_de_Tareas.Models
{
    public class Comments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idComment {  get; set; }
        public string descriptionCommet { get; set; }
        public virtual ICollection<AuxiliarT> AuxiliarT { get; set; } = new List<AuxiliarT>();
    }
}
