using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCollection.Models.ViewModels.Requests
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
