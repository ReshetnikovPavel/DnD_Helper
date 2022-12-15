using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndHelper.App.Authentication
{
    public class AuthenticationToken
    {
        public string Token { get; }
        public AuthenticationToken(string token)
        {
            Token = token;
        }
    }
}
