using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Dto
{
    public class RolDto
    {
        public int IdRol { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<UsersDto> User { get; set; } = new List<UsersDto>();
        public virtual ICollection<OperacionesDto> Operacion { get; set; } = new List<OperacionesDto>();

    }
}
