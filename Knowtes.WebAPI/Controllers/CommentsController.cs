using Microsoft.AspNetCore.Mvc;
using Platinum.WebAPI.Commands.Comments;
using Platinum.WebAPI.Commands.Games;
using Platinum.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        //Вывод списка комментариев
        [HttpGet]
        //[Authorize]
        public IActionResult GetComments([FromQuery] int AchivementId)
        {
            GetCommentsCommand command = new GetCommentsCommand();
            List<Comment> comments = command.Execute(AchivementId);
            return Ok(comments);
        }

        //добавление данных об игре
        [HttpPost]
        //[Authorize]
        public IActionResult Create([FromBody] Comment comment)
        {
            CreateCommentCommand command = new CreateCommentCommand();

            if (command.Execute(comment))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
