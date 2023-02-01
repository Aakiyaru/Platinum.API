using Knowtes.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Models
{
    public class Game : BaseModel
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Realease { get; set; }
        public string Cover { get; set; }
    }
}
