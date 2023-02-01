using Knowtes.WebAPI.Commands;
using Knowtes.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platinum.WebAPI.Commands;
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
    public class GamesController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
        {
            GetAllGamesCommand command = new GetAllGamesCommand();
            List<Game> games = command.Execute();
            return Ok(games);
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize]
        public IActionResult Get(int id)
        {
            GetGameCommand command = new GetGameCommand();
            Game game = command.Execute(id);
            return Ok(game);
        }

        //[HttpPost]
        //[Authorize]
        //public IActionResult Create([FromBody] Note note)
        //{
        //    CreateNoteCommand command = new CreateNoteCommand();

        //    note.Creator = User.Identity.Name;

        //    if (command.Execute(note))
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //TODO: - Метод Get one
        //TODO: - Метод Post
        //TODO: - Метод Update
        //TODO: - Метод Delete
    }
}
