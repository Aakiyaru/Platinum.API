using Knowtes.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Models
{
    public class Comment : BaseModel
    {
        public int UserId { get; set; }
        public string Text { get; set; }
        public int AchivementId { get; set; }
    }
}
