﻿using Knowtes.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platinum.WebAPI.Models
{
    public class Achivement : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int GameId { get; set; }
        public string Icon { get; set; }
    }
}
