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
    }
}
