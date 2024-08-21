using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;

namespace P_Asignación_de_Tareas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProyectsController : Controller
    {
        public ApplicationDbcontext _dbcontext;

        public ProyectsOperations _operations;
        public ProyectsController(ProyectsOperations notification, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _operations = notification;
        }

        [HttpGet("GetProyects")]
        public async Task<IActionResult> GetProyects()
        {
            var result = await _operations.GetProyects();

            return Ok(result);
        }

        [HttpGet("GetProyect/{idProyect}")]
        public async Task<IActionResult> GetProyect(int idProyect)
        {
            var result = await _operations.GetProyect(idProyect);

            return Ok(result);
        }

        [HttpPost("CreateProyect")]
        public async Task<IActionResult> CreateProyect(ProyectsDto proyectsDto)
        {
            Proyects proyects = new Proyects()
            {
                idTasks = proyectsDto.idTasks,
                nameProyect = proyectsDto.nameProyect,
            };

            var result = await _operations.CreateProyect(proyects);

            return Ok(result);
        }

        [HttpPut("UpdateProyect/{idProyect}")]
        public async Task<bool> UpdateProyect(ProyectsDto proyects)
        {
            var result = await _operations.UpdateProyect(proyects);

            return result;
        }

        [HttpDelete("DeleteProyect/{idProyect}")]
        public async Task<bool> DeleteProyect(int idProyect)
        {
            var result = await _operations.DeleteProyect(idProyect);

            return result;
        }
    }
}
