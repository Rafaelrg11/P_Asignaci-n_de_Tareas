namespace P_Asignación_de_Tareas.Dto
{
    public class NotificationsDto
    {
        public int idNotification { get; set; }
        public int idUser { get; set; }
        public string nameNotification { get; set; }
        public string descriptionNotification { get; set; }
        public UsersDto UserDto { get; set; }
    }
}
