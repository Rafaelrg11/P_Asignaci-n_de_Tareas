using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;

namespace P_Asignación_de_Tareas.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public ApplicationDbcontext _dbcontext;

        public UsersOperations _operations;
        public UsersController(UsersOperations operations,ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _operations = operations;
        }

        public async Task<IActionResult> Login([FromBody] UsersDto usersDto)
        {

        }


    }
}
