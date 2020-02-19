using System;
using System.Collections.Generic;
using System.Text;

namespace TopCine.Domain.Features.Users
{
    public class User
    {
        public User() { }

        public User(long id, String name, String email, String password, AccessLevelEnum accessLevel)
        {
            Id = id;
            Name = name;
            Email = email;
            AccessLevel = accessLevel;
            Password = password;
        }

        public long Id { get; private set; }

        public String Name { get; private set; }

        public String Email { get; private set; }

        public AccessLevelEnum AccessLevel { get; private set; }

        public String Password { get; private set; }

        public String Token { get; private set; }

        public DateTime InsertDate { get; private set; }

        public Nullable<DateTime> UpdateDate { get; private set; }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetToken(string token)
        {
            Token = token;
        }
    }
}
