using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;


namespace P_Asignación_de_Tareas.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OperacionesController : Controller
    {
        public OperacionesOperation _ope;

        public ApplicationDbcontext _context;
        public OperacionesController(ApplicationDbcontext dbcontext, OperacionesOperation operaciones)
        {
            _ope = operaciones;
            _context = dbcontext;
        }

        [HttpGet("GetOperaciones")]
        public async Task<IActionResult> GetOperaciones()
        {
            var result = await _ope.GetOperaciones();

            return Ok(result);
        }

        [HttpGet("GetOperacion/{idOperacion}")]
        public async Task<IActionResult> GetOperacion(int idOperacion)
        {
            var result = await _ope.GetOperation(idOperacion);

            return Ok(result);
        }

        [HttpPost("CreateOperacion")]
        public async Task<IActionResult> CreateOperacion(OperacionesDto dto)
        {
            OperationsXd operaciones = new OperationsXd()
            {
                IdOperationRol = dto.IdOperationRol,
                IdRol = dto.IdRol,
            };
            var operation = await _ope.CreateOperations(operaciones);

            return Ok(operation);
        }

        [HttpPut("UpdateOperacion/{idOperacion}")]
        public async Task<bool> UpdateOperacion(OperacionesDto operaciones)
        {
            var result = await _ope.UpdateOperation(operaciones);

            return result;
        }

        [HttpDelete("DeleteOperacion/{idOperacion}")]
        public async Task<bool> DeleteOperacion(int idOperacion)
        {
            var result = await _ope.DeleteOperaion(idOperacion);
                
            return result;
            }
        }
    }