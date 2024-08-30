namespace P_Asignación_de_Tareas.Dto
{
    public class AuxiliarTDto2
    {
        public int idAuxiliar { get; set; }
        public int idUser { get; set; }
        public int idProyect { get; set; }
        public UsersCustomDto UserDto { get; set; }
        public ProyectDto2 proyectDto { get; set; }

    }
}
