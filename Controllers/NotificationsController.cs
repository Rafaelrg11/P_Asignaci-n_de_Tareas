using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;

namespace P_Asignación_de_Tareas.Controllers
{ 
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

        [HttpGet("GetNotifications")]
        public async Task<IActionResult> GetNotifications()
        {
            var result = await _operations.GetNotifications();

            return Ok(result);
        }

        [HttpGet("GetNotification/{idNotifi}")]
        public async Task<IActionResult> GetNotifications(int idNotifi)
        {
            var result = await _operations.GetNotification(idNotifi);

            return Ok(result);
        }

        [HttpPost("CreateNotification")]
        public async Task<IActionResult> CreateNotification(NotificationsDto notifications)
        {
            Notifications notifi = new Notifications()
            {
                nameNotification = notifications.nameNotification,
                descriptionNotification = notifications.descriptionNotification,
            };

            var operations = await _operations.CreateNotification(notifi);

            return Ok(operations);
        }


    }
}
