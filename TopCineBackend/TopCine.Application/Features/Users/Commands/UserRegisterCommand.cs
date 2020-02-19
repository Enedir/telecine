using System;
using System.Collections.Generic;
using System.Text;
using TopCine.Domain.Features.Users;

namespace TopCine.Application.Features.Users.Commands
{
    public class UserRegisterCommand
    {
        public String Name { set; get; }

        public String Email { set; get; }

        public AccessLevelEnum AccessLevel { set; get; }

        public String Password { set; get; }
    }
}
