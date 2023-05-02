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
        public long UserId { get; set; }
        public string Text { get; set; }
        public long AchivementId { get; set; }
    }
}
