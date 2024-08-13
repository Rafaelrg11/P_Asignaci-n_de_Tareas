using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;

namespace P_Asignación_de_Tareas.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : Controller
    {
        public ApplicationDbcontext _dbcontext;

        public NotificationOperations _operations;
        public NotificationsController(NotificationOperations notification,ApplicationDbcontext dbcontext)
        {           
            _dbcontext = dbcontext;
            _operations = notification;
        }
    }
}
