using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Asignación_de_Tareas.Dto;
using P_Asignación_de_Tareas.Models;
using P_Asignación_de_Tareas.Operaciones;
using System.Xml.Linq;

namespace P_Asignación_de_Tareas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        public ApplicationDbcontext _dbcontext;

        public CommentOperations _operations;
        public CommentsController(CommentOperations notification, ApplicationDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
            _operations = notification;
        }

        [HttpGet("GetComments")]
        public async Task<IActionResult> GetComments()
        {
            var result = await _operations.GetComments();

            return Ok(result);
        }

        [HttpGet("GetComment/{idComment}")]
        public async Task<IActionResult> GetComment(int idComment)
        {
            var result = await _operations.GetComment(idComment);

            return Ok(result);
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CommentsDto commentsDto)
        {
            Comments comments = new Comments()
            {
                descriptionCommet = commentsDto.descriptionCommet,
            };

            var result = await _operations.CreateComment(comments);

            return Ok(result);
        }

        [HttpPut("UpdateComment/{idComment}")]
        public async Task<bool> UpdateComment(CommentsDto commentsDto)
        {
            var result = await _operations.UpdateComment(commentsDto);

            return result;
        }

        [HttpDelete("DeleteComment/{idComment}")]
        public async Task<bool> DeleteComment(int idComment)
        {
            var result = await _operations.DeleteComment(idComment);

            return result;
        }
    }
}
