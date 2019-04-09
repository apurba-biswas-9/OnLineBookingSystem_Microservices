using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.DataModel
{
    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
        public UserType UserCategory { get; set; }
    }
}
