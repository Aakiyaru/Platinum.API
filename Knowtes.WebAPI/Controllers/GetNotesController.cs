using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Knowtes.WebAPI.Commands;
using Knowtes.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Knowtes.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetNotesController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            GetAllNotesCommand command = new GetAllNotesCommand();
            List<Note> notes = command.Execute(User.Identity.Name);
            return Ok(notes);
        }
    }
}
