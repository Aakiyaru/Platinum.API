using Microsoft.AspNetCore.Mvc;
using Platinum.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    List<Achivement> achivements = (from ach in db.Achivements
                                                    where ach.GameId == gameId
                                                    select ach).ToList();
                    return Ok(achivements);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("getOne")]
        //[Authorize]
        public IActionResult Get([FromQuery]int id, [FromQuery] int gameId)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Achivement achive = (from ach in db.Achivements
                                         where ach.GameId == gameId && ach.Id == id
                                         select ach).FirstOrDefault();
                    return Ok(achive);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
