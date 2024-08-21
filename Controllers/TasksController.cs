using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;

namespace P_Asignación_de_Tareas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : Controller
    {
        public ApplicationDbcontext _dbcontext;

        public TasksOperations _operations;
        public TasksController(TasksOperations notification, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _operations = notification;
        }

        [HttpGet("GetTasks")]
        public async Task<IActionResult> GetTasks()
        {
            var result = await _operations.GetTasks();

            return Ok(result);
        }

        [HttpGet("GetTask/{idTask}")]
        public async Task<IActionResult> GetTask(int idTask)
        {
            var result = await _operations.GetTask(idTask);

            return Ok(result);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(TasksDto tasksDto)
        {
            Tasks task = new Tasks()
            {
                descriptionTask = tasksDto.descriptionTask,
                nameTask = tasksDto.nameTask,
                dateTask = tasksDto.dateTask,
                dateTaskCompletion = tasksDto.dateTaskCompletion
            };

            var result = await _operations.CreateTask(task);

            return Ok(task);
        }

        [HttpPut("UpdateTask/{idTask}")]
        public async Task<bool> UpdateTask(TasksDto tasksDto)
        {
            var result = await _operations.UpdateTask(tasksDto);

            return result;
        }

        [HttpDelete("DeleteTask/{idTask}")]
        public async Task<bool> DeleteTask(int idTask)
        {
            var result = await _operations.DeleteTask(idTask);

            return result;
        }
    }
}
