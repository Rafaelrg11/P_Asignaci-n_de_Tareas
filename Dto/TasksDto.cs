namespace P_Asignación_de_Tareas.Dto
{
    public class TasksDto
    {
        public int idTask { get; set; }
        public int idProyect { get; set; }
        public string nameTask { get; set; }
        public string descriptionTask { get; set; }
        public DateTime dateTask { get; set; }
        public DateTime dateTaskCompletion { get; set; }
        public string state {  get; set; }
        public virtual ProyectsDto proyects { get; set; }
        public ICollection<CommentsDto> comments { get; set; } = new List<CommentsDto>();
    }
}
