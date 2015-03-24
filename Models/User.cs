using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string  DisplayName { get; set; }
        public string Email { get; set; }

        public virtual DetailInfo DetailInfo{ get; set; }
    }
}
