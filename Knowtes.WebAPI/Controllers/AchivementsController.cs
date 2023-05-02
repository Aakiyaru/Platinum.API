using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platinum.WebAPI.Commands.Achivements;
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
    public class AchivementsController : ControllerBase
    {
        [HttpGet]
        //[Authorize]
        public IActionResult GetAll([FromQuery] int gameId)
        {
            GetAllAchivementsCommand command = new GetAllAchivementsCommand();
            List<Achivement> achivement = command.Execute(gameId);
            return Ok(achivement);
        }

        [HttpGet]
        [Route("getOne")]
        //[Authorize]
        public IActionResult Get([FromQuery]int id, [FromQuery] int gameId)
        {
            GetAchivementCommand command = new GetAchivementCommand();
            Achivement achivement = command.Execute(id, gameId);
            return Ok(achivement);
        }
    }
}
