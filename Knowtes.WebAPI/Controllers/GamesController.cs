using Microsoft.AspNetCore.Mvc;
using Platinum.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                using (ApplicationContext db =  new ApplicationContext())
                {
                    List<Game> gms = db.Games.ToList();
                    return Ok(gms);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        //вывод данных по одной игре
        [HttpGet]
        [Route("{id}")]
        //[Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext ())
                {
                    Game gm = (from _gm in db.Games
                               where _gm.Id == id
                               select  _gm).FirstOrDefault();
                    return Ok(gm);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        //поиск
        [HttpGet]
        [Route("search")]
        //[Authorize]
        public IActionResult Search([FromQuery] string searchString)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    List<Game> gms = (from _gm in db.Games
                                      where _gm.Name.Contains(searchString)
                                      select _gm).ToList();
                    return Ok(gms);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        //добавление данных об игре
        [HttpPost]
        //[Authorize]
        public IActionResult Create([FromBody] Game game)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Games.Add(game);
                    db.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
