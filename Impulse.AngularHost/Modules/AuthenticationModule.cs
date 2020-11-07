using System;
using Impulse.AngularHost;
using Impulse.AngularHost.Models;

namespace Impulse.AngularHost.Modules
{
    public class AuthenticationModule
    {
        public bool Validate(LoginRequest login)
        {
            if (login.Username.IsNullOrEmpty() || login.Password.IsNullOrEmpty())
                return false;
            
            // Do DB check
            

            throw new NotImplementedException();
        }
    }

    public class ProfileModule
    {

    }

    public class ClaimsModule
    {

    }
}