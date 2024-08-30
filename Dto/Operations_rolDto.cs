using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Dto
{
    public class Operations_rolDto
    {
        public int IdOperationsRol { get; set; }
        public string NameOperationRol { get; set; }
        public int IdModulo { get; set; }
        public ModuleDto2 module { get; set; }
        public virtual ICollection<OperacionesDto2> Operaciones { get; set; } = new List<OperacionesDto2>();
    }
}
