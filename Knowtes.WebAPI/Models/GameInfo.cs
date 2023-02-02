using Knowtes.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Models
{
    public class GameInfo : Game
    {
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Realease { get; set; }
    }
}
