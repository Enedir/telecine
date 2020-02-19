using System;
using System.Collections.Generic;
using System.Text;

namespace TopCine.Domain.Features.Users
{
    public interface IUserRepository
    {
        User Save(User entity);

        bool Update(User entity);

        User Get(long id);

        IList<User> GetAll();

        IList<User> GetAll(int size);

        bool Delete(long entityId);

        User GetByEmailAndPassword(string email, string password);

    }
}
