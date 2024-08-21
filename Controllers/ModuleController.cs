using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;

namespace P_Asignación_de_Tareas.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class ModuleController : Controller
    {
        public ApplicationDbcontext _context;
        public ModuleOperations _operation;

        public ModuleController(ModuleOperations operations, ApplicationDbcontext context) 
        {
            _context = context;
            _operation = operations;
        }

        [HttpGet("GetMudules")]
        public async Task<IActionResult> GetModules()
        {
            var result = await _operation.GetModules();

            return Ok(result);
        }
        [HttpGet("GetModule/{idModule}")]
        public async Task<IActionResult> GetModule(int idModule)
        {
            var result = await _operation.GetModule(idModule);

            return Ok(result);
        }

        [HttpPost("CreateModule")]
        public async Task<IActionResult> CreateModule(ModuleDto moduleDto)
        {
            Module module = new Module()
            {
                NameMod = moduleDto.NameMod,
            };
            
            var operation = await _operation.CreateModule(module);

            return Ok(operation);
        }

        [HttpPut("UpdateModule/{idModule}")]
        public async Task<bool> UpdateModule(ModuleDto moduleDto)
        {
            var operation = await _operation.UpdateModule(moduleDto);

            return operation;
        }

        [HttpDelete("DeleteModule/{idModule}")]
        public async Task<bool> DeleteModule(int idModule)
        {
            bool operation = await _operation.DeleteModule(idModule);

            return operation;
        }
    }
}
