using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;

namespace P_Asignación_de_Tareas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuxiliarTController : Controller
    {
        public AuxiliarTOperations _operations;
        public AuxiliarTController(AuxiliarTOperations operations)
        {
            _operations = operations;
        }

        [HttpGet("GetAuxiliars")]
        public async Task<IActionResult> GetAuxiliars()
        {
            var result = await _operations.GetAuxiliars();

            return Ok(result);
        }

        [HttpGet("GetAuxiliar/{idAuxiliar}")]
        public async Task<IActionResult> GetAuxiliar(int idAuxiliar)
        {
            var result = await _operations.GetAuxiliar(idAuxiliar);

            return Ok(result);
        }

        [HttpPost("CreateAuxiliar")]
        public async Task<IActionResult> CreateAuxiliar(AuxiliarTDto auxiliarTDto)
        {
            AuxiliarT auxiliarT = new AuxiliarT()
            {
                idCommet = auxiliarTDto.idCommet,
                idNotification = auxiliarTDto.idNotification,
                idProyect = auxiliarTDto.idProyect,
                idUser = auxiliarTDto.idUser
            };
            var operation = await _operations.CreateAuxiliarT(auxiliarT);

            return Ok(operation);
        }
    }
}
