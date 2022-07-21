using System;
using Knowtes.Backend.Models;

namespace Knowtes.WebAPI.Models
{
    public class Note : BaseModel
    {
        public string Creator { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
