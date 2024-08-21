using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Operaciones
{
    public class NotificationOperations
    {
        public ApplicationDbcontext _context;
        public NotificationOperations(ApplicationDbcontext dbcontext) 
        {
            _context = dbcontext;
        }

        public async Task<List<Notifications>> GetNotifications()
        {
            var result = await _context.Notifications.AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<Notifications> GetNotification(int idNotification)
        {
            var result =  await _context.Notifications.FindAsync(idNotification);

            return result;
        }

        public async Task<Notifications> CreateNotification(Notifications notifications)
        {
            var result = await _context.Notifications.AddAsync(notifications);

            await _context.SaveChangesAsync();

            return notifications;
        }

        public async Task<bool> UpdateNotification(NotificationsDto notificationsDto)
        {
            Notifications? notifications = await _context.Notifications.FindAsync(notificationsDto);
            if (notifications != null) 
            {
                notifications.descriptionNotification = notificationsDto.descriptionNotification;
                notifications.nameNotification = notificationsDto.nameNotification;

                await _context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> DeleteNotification(int idNotification)
        {
            var result = await _context.Notifications.FindAsync(idNotification);
            if (result == null)
            {
                return false;
            }

            _context.Notifications.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
