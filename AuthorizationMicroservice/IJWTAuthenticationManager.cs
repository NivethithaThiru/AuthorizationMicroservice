using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorizationMicroservice.Models;

namespace AuthorizationMicroservice
{
    public interface IJWTAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
