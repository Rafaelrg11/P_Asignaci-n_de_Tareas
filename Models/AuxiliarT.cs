using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P_Asignación_de_Tareas.Models
{
    public class AuxiliarT
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idAuxiliar { get; set; }

        [ForeignKey("idUser")]
        public int idUser { get; set; }

        [ForeignKey("idProyect")]
        public int idProyect { get; set; }

        [ForeignKey("idCommet")]
        public int idCommet { get; set; }

        [ForeignKey("idNotification")]
        public int idNotification { get; set; }
           
    }
}
