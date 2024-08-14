using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P_Asignación_de_Tareas.Models
{
    public class AuxiliarT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAuxiliar { get; set; }       
        public int idUser { get; set; }
        public int idProyect { get; set; }
        public int idCommet { get; set; }
        public int idNotification { get; set; }
    }
}
