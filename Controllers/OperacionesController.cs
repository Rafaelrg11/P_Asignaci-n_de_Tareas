using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            await _ope.GetOperaciones();

            var AllOperations = await _context.Operations.Select(a => new OperacionesDto
            {
                IdOperaciones = a.IdOperaciones,
                IdOperationRol = a.IdOperationRol,
                IdRol = a.IdRol,
                Rol = new RolDto2
                {
                    IdRol = a.IdRol,
                    nombre = a.Rol.nombre
                },
                operations_Rol = new Operations_rolDto2
                {
                    IdOperationsRol = a.IdOperationRol,
                    NameOperationRol = a.OperationsRol.NameOperationRol
                }
            }).ToListAsync();

            return Ok(AllOperations);
        }

        [HttpGet("GetOperacion/{idOperacion}")]
        public async Task<IActionResult> GetOperacion(int idOperacion)
        {
            await _ope.GetOperation(idOperacion);

            var operation = await _context.Operations.Where(a => a.IdOperaciones == idOperacion).Select(a => new OperacionesDto
            {
                IdOperaciones = a.IdOperaciones,
                IdOperationRol = a.IdOperationRol,
                IdRol = a.IdRol,
                Rol = new RolDto2
                {
                    IdRol = a.IdRol,
                    nombre = a.Rol.nombre
                },
                operations_Rol = new Operations_rolDto2
                {
                    IdOperationsRol = a.IdOperationRol,
                    NameOperationRol = a.OperationsRol.NameOperationRol
                }
            }).ToListAsync();

            return Ok(operation);
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