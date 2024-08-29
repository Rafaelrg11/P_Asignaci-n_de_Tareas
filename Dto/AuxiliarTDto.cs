using System.ComponentModel.DataAnnotations.Schema;

namespace P_Asignación_de_Tareas.Dto
{
    public class AuxiliarTDto
    {
        public int idAuxiliar { get; set; }
        public int idUser { get; set; }    
        public int idProyect { get; set; }    
    }
}
