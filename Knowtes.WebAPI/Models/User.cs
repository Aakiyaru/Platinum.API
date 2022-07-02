using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowtes.Backend.Models
{
    public class User : BaseModel
    {
        public string name { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
