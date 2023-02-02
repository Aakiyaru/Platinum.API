using Microsoft.AspNetCore.Mvc;
using Platinum.WebAPI.Commands.Games;
using Platinum.WebAPI.Models;
using System.Collections.Generic;

namespace Platinum.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        //вывод списка игр
        [HttpGet]
        //[Authorize]
        public IActionResult GetList()
        {
            GetAllGamesCommand command = new GetAllGamesCommand();
            List<Game> games = command.Execute();
            return Ok(games);
        }

        //вывод данных по одной игре
        [HttpGet]
        [Route("{id}")]
        //[Authorize]
        public IActionResult Get(int id)
        {
            GetGameCommand command = new GetGameCommand();
            GameInfo game = command.Execute(id);
            return Ok(game);
        }

        //добавление данных об игре
        [HttpPost]
        //[Authorize]
        public IActionResult Create([FromBody] GameInfo game)
        {
            CreateGameCommand command = new CreateGameCommand();

            if (command.Execute(game))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //TODO: - Метод Update
        //TODO: - Метод Delete
    }
}
