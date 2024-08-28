using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;

namespace P_Asignación_de_Tareas.Operaciones
{
    public class TasksOperations
    {
        public ApplicationDbcontext _dbcontext;
        public TasksOperations(ApplicationDbcontext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<List<Tasks>> GetTasks()
        {
            var tasks = await _dbcontext.Tasks.AsNoTracking().ToListAsync();

            return tasks;
        }

        public async Task<Tasks> GetTask(int iduser)
        {
            var tasks = await _dbcontext.Tasks.FindAsync(iduser);

            return tasks;
        }

        public async Task<Tasks> CreateTask(Tasks task)
        {
            var tasks = await _dbcontext.Tasks.AddAsync(task);

            await _dbcontext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> UpdateTask(TasksDto tasksDto)
        {
            Tasks? tasks = await _dbcontext.Tasks.FindAsync(tasksDto.idTask);

            if (tasks != null)
            {
                tasks.dateTaskCompletion = tasksDto.dateTaskCompletion;
                tasks.dateTask = tasksDto.dateTask;
                tasks.descriptionTask = tasksDto.descriptionTask;
                tasks.nameTask = tasksDto.nameTask;              

                await _dbcontext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteTask(int idtask)
        {
            var result = await _dbcontext.Tasks.FindAsync(idtask);
            if (result == null)
            {
                return false;
            }

            _dbcontext.Tasks.Remove(result);

            await _dbcontext.SaveChangesAsync();

            return true;

        }
    }
}
