using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;

namespace P_Asignación_de_Tareas.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class RolController : Controller
    {
        public ApplicationDbcontext _context;

        public RolOperation _operation;
        public RolController(ApplicationDbcontext applicationDbcontext, RolOperation operation) 
        {
            _context = applicationDbcontext;
            _operation = operation;
        }

        [HttpGet("GetRols")]
        public async Task<IActionResult> GetRols()
        {
            var result = await _operation.GetRols();

            return Ok(result);
        }

        [HttpGet("GetRol/{idRol}")]
        public async Task<IActionResult> GetRol(int idRol)
        {
            var result = await _operation.GetRol(idRol);

            return Ok(result);
        }

        [HttpPost("CreateRol")]
        public async Task<IActionResult> CreateRol([FromBody] RolDto rolDto)
        {
            Rol rol = new Rol()
            {
                nombre = rolDto.nombre,               
            };
            var operation = await _operation.CreateRol(rol);

            return Ok(operation);
        }

        [HttpPut("UpdateRol/{idRol}")]
        public async Task<bool> UpdateRol([FromBody] RolDto rol)
        {
            var operation = await _operation.UpdateRol(rol);

            return operation;
        }

        [HttpDelete("DeleteRol/{idRol}")]
        public async Task<bool> DeleteRol(int idRol)
        {
            var result = await _operation.DeleteRol(idRol);

            return result;
        }
    }
}
