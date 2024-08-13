namespace P_Asignación_de_Tareas.Dto
{
    public class TasksDto
    {
        public int idTask { get; set; }
        public string nameTask { get; set; }
        public string descriptionTask { get; set; }
        public DateTime dateTask { get; set; }
        public DateTime dateTaskCompletion { get; set; }
    }
}
