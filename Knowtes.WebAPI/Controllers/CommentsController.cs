using Microsoft.AspNetCore.Mvc;
using Platinum.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    List<Comment> coms = (from ach in db.Comments
                                              where ach.AchivementId == AchivementId
                                              select ach).ToList();
                    return Ok(coms);
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
        public IActionResult Create([FromBody] Comment comment)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Comments.Add(comment);
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
