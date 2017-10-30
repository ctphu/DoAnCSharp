using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class UserBO
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsDisable { get; set; }
    }
}
