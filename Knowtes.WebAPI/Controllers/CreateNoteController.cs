using Knowtes.WebAPI.Commands;
using Knowtes.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Knowtes.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CreateNoteController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult Create([FromBody] Note note)
        {
            CreateNoteCommand command = new CreateNoteCommand();

            note.Creator = User.Identity.Name;

            if(command.Execute(note))
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
