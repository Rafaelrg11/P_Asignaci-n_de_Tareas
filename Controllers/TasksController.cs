using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            await _operations.GetTasks();

            var allTasks = await _dbcontext.Tasks.Select(a => new TasksDto
            {
                idProyect = a.idProyect,
                idTask = a.idTask,
                nameTask = a.nameTask,
                descriptionTask = a.descriptionTask,
                dateTask = a.dateTask,
                dateTaskCompletion = a.dateTaskCompletion,
                state = a.state,
                proyects = new ProyectsDto
                {
                    idProyect = a.idProyect,
                    nameProyect = a.Proyects.nameProyect
                },
                comments = a.Comment.Select(a => new CommentsDto
                {
                    idComment = a.idComment,
                    idTask = a.idTask,
                    descriptionCommet = a.descriptionCommet
                }).ToList()
            }).ToListAsync();

            return Ok(allTasks);
        }

        [HttpGet("GetTask/{idTask}")]
        public async Task<IActionResult> GetTask(int idTask)
        {
            await _operations.GetTask(idTask);

            var task = await _dbcontext.Tasks.Where(a => a.idTask == idTask).Select(a => new TasksDto
            {
                idProyect = a.idProyect,
                idTask = a.idTask,
                nameTask = a.nameTask,
                descriptionTask = a.descriptionTask,
                dateTask = a.dateTask,
                dateTaskCompletion = a.dateTaskCompletion,
                state = a.state,
                proyects = new ProyectsDto
                {
                    idProyect = a.idProyect,
                    nameProyect = a.Proyects.nameProyect
                },
                comments = a.Comment.Select(a => new CommentsDto
                {
                    idComment = a.idComment,
                    idTask = a.idTask,
                    descriptionCommet = a.descriptionCommet
                }).ToList()
            }).ToListAsync();

            /*if (result.dateTask == result.dateTaskCompletion)
            {
                result.state = "Terminada";
            }*/

            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTask(TasksDto tasksDto)
        {
            Tasks task = new Tasks()
            {
                descriptionTask = tasksDto.descriptionTask,
                nameTask = tasksDto.nameTask,
                dateTask = tasksDto.dateTask,
                dateTaskCompletion = tasksDto.dateTaskCompletion,
                idProyect = tasksDto.idProyect,     
                state = tasksDto.state,
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
