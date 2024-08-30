using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Dto
{
    public class RolDto
    {
        public int IdRol { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<UserDto2> User { get; set; } = new List<UserDto2>();
        public virtual ICollection<OperacionesDto2> Operacion { get; set; } = new List<OperacionesDto2>();

    }
}
