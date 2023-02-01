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

        //TODO: - Метод Get one

        //[HttpGet]
        //[Route("{id}")]
        //[Authorize]
        //public IActionResult Get(int id)
        //{
        //    GetNoteCommand command = new GetNoteCommand();
        //    Note note = command.Execute(User.Identity.Name, id);
        //    return Ok(note);
        //}

        //TODO: - Метод Delete

        //TODO: - Метод Post

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

        //TODO: - Метод Update
    }
}
