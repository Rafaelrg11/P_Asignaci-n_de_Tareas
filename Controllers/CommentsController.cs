﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            await _operations.GetComments();

            var AllComments = await _dbcontext.Comments.Select(a => new CommentsDto
            {
                idComment = a.idComment,
                idTask = a.idTask,
                descriptionCommet = a.descriptionCommet,
                tasksDto = new TasksDto2
                {
                    idTask = a.idTask,
                    nameTask = a.Tasks.nameTask,
                    descriptionTask = a.Tasks.descriptionTask,
                    dateTask = a.Tasks.dateTask,
                    dateTaskCompletion = a.Tasks.dateTaskCompletion,
                    state = a.Tasks.state
                }
            }).ToListAsync();

            return Ok(AllComments);
        }

        [HttpGet("GetComment/{idComment}")]
        public async Task<IActionResult> GetComment(int idComment)
        {
            await _operations.GetComment(idComment);

            var Comment = await _dbcontext.Comments.Where(a => a.idComment == idComment).Select(a => new CommentsDto
            {
                idComment = a.idComment,
                idTask = a.idTask,
                descriptionCommet = a.descriptionCommet,
                tasksDto = new TasksDto2
                {
                    idTask = a.idTask,
                    nameTask = a.Tasks.nameTask,
                    descriptionTask = a.Tasks.descriptionTask,
                    dateTask = a.Tasks.dateTask,
                    dateTaskCompletion = a.Tasks.dateTaskCompletion,
                    state = a.Tasks.state
                }
            }).ToListAsync();

            return Ok(Comment);
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CommentsDto commentsDto)
        {
            Comments comments = new Comments()
            {
                descriptionCommet = commentsDto.descriptionCommet,
                idTask = commentsDto.idTask,
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
