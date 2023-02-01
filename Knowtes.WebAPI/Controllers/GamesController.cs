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
        //вывод списка игр
        [HttpGet]
        //[Authorize]
        public IActionResult GetAll()
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
            Game game = command.Execute(id);
            return Ok(game);
        }

        //добавление данных об игре
        [HttpPost]
        //[Authorize]
        public IActionResult Create([FromBody] Game game)
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

        //TODO: - Метод Post
        //TODO: - Метод Update
        //TODO: - Метод Delete
    }
}
