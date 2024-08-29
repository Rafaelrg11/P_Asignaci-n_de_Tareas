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
    public class Operations_RolController : Controller
    {
        public ApplicationDbcontext _context;

        public Operation_RolOperations _operation;

        public Operations_RolController(ApplicationDbcontext dbcontext, Operation_RolOperations operation)
        {
            _context = dbcontext;
            _operation = operation;
        }

        [HttpGet("GetOperationsRols")]
        public async Task<IActionResult> GetOperationsRols()
        {
             await _operation.GetOperations_Rols();

            var allOperationsRols = await _context.OperationRols.Select(a => new Operations_rolDto
            {
                IdOperationsRol = a.IdOperationsRol,
                IdModulo = a.IdModulo,
                NameOperationRol = a.NameOperationRol,
                module = new ModuleDto
                {
                    NameMod = a.Module.NameMod,
                    IdMod = a.IdModulo
                },
                Operaciones = a.Operaciones.Select(a => new OperacionesDto
                {
                    IdOperaciones = a.IdOperaciones,
                    IdOperationRol = a.IdOperationRol,
                    IdRol = a.IdRol
                }).ToList()
            }).ToListAsync();

            return Ok(allOperationsRols);
        }

        [HttpGet("GetOperationRol/{idOpeRol}")]
        public async Task<IActionResult> GetOperationRol(int idOpeRol)
        {
            _operation.GetOperations_Rol(idOpeRol);

            var OperationsRol = await _context.OperationRols.Where(a => a.IdOperationsRol == idOpeRol).Select(a => new Operations_rolDto
            {
                IdOperationsRol = a.IdOperationsRol,
                IdModulo = a.IdModulo,
                NameOperationRol = a.NameOperationRol,
                module = new ModuleDto
                {
                    NameMod = a.Module.NameMod,
                    IdMod = a.IdModulo
                },
                Operaciones = a.Operaciones.Select(a => new OperacionesDto
                {
                    IdOperaciones = a.IdOperaciones,
                    IdOperationRol = a.IdOperationRol,
                    IdRol = a.IdRol
                }).ToList()
            }).ToListAsync();

            return Ok(OperationsRol);
        }

        [HttpPost("CreateOperationRol")]
        public async Task<IActionResult> CreateOperationRol(Operations_rolDto operations_RolDto)
        {
                Operations_Rol operations_Rol = new Operations_Rol()
                { 
                    NameOperationRol = operations_RolDto.NameOperationRol,
                    IdModulo = operations_RolDto.IdModulo
                };

                var operation = await _operation.CreateOperationRols(operations_Rol);

                return Ok(operation);            
        }

        [HttpPut("UpdateOperationRol/{idOpeRol}")]
        public async Task<bool> UpdateUpdateOperationRol(Operations_rolDto operations_RolDto)
        {
            var operation = await _operation.UpdateOperationRol(operations_RolDto);

            return operation;
        }

        [HttpDelete("DeleteOperationRol/{idOpeRol}")]
        public async Task<IActionResult> DeleteOperationRol(int idOpeRol)
        {
            bool operation = await _operation.DeleteOperationRol(idOpeRol);

            return Ok(idOpeRol);
        }
    }
}
