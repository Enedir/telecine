using System;
using System.Collections.Generic;
using System.Text;
using TopCine.Domain.Features.Users;

namespace TopCine.Application.Features.Users
{
    public interface IUserService
    {
        long Add(User user);

        bool Update(User user);

        User Get(long id);

        IList<User> GetAll();

        //IList<User> GetAll(ConveyorQuery query);

        bool Delete(long id);
    }
}
