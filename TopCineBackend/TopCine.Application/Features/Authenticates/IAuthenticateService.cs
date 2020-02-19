using System;
using System.Collections.Generic;
using System.Text;
using TopCine.Domain.Features.Users;

namespace TopCine.Application.Features.Authenticates
{
    public interface IAuthenticateService
    {
        User Authenticate(string email, string password);
    }
}
