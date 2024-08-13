using System.ComponentModel.DataAnnotations.Schema;

namespace P_Asignación_de_Tareas.Dto
{
    public class ProyectsDto
    {
        public int idProyect { get; set; }
        public int idTasks { get; set; }        
        public string nameProyect { get; set; }
    }
}
