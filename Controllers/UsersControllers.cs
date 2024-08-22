using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace P_Asignación_de_Tareas.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        public ApplicationDbcontext _dbcontext;

        private readonly string _secretkey;

        public UsersOperations _operations;
        public UsersController(IConfiguration configuration, UsersOperations operations, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _operations = operations;
            _secretkey = configuration.GetSection("Jwt").GetSection("Key").ToString();


        }

        [HttpPost("Validation")]
        public IActionResult Login([FromBody] UsersDto usersDto)
        {
            var users = (from d in _dbcontext.Users
                         where d.nameUser == usersDto.nameUser.Trim() && d.password == usersDto.password
                         && d.emailUser == usersDto.emailUser.Trim() 
                         select d).FirstOrDefault();

            if (users != null)
            {
                var keyBytes = Encoding.ASCII.GetBytes(_secretkey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usersDto.emailUser));

                var token = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfig = tokenHandler.CreateToken(token);

                string tokenCreated = tokenHandler.WriteToken(tokenConfig);

                return StatusCode(StatusCodes.Status200OK, new { token = tokenCreated });

            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }


        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _operations.GetUsers();

            return Ok(result);
        }

        [HttpGet("GetUser/{idUser}")]
        public async Task<IActionResult> GetUSer(int idUser)
        {
            var result = await _operations.GetUser(idUser);

            return Ok(result);
        }

        [Authorize(Roles = "Creator")]
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UsersDto usersDto)
        {   
                Users users = new Users()
                {
                    nameUser = usersDto.nameUser,
                    emailUser = usersDto.emailUser,
                    password = usersDto.password,      
                    IdRol = usersDto.IdRol
                };

                var operation = await _operations.CreateUser(users);

                return Ok(operation);
        }
    }
}
