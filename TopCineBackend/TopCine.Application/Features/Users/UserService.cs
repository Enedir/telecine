using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using TopCine.Domain.Features.Users;
using TopCine.Infra.Extension_Methods;

namespace TopCine.Application.Features.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _reposotory;

        public UserService(IUserRepository repository)
        {
            _reposotory = repository;
        }

        public long Add(User user)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var passwordHash = md5Hash.GetMd5Hash(user.Password);
                user.SetPassword(passwordHash);

                var newEntity = _reposotory.Save(user);

                return newEntity.Id;
            }
        }

        public bool Delete(long id)
        {
            return _reposotory.Delete(id);

        }

        public User Get(long id)
        {
            return _reposotory.Get(id);
        }

        public IList<User> GetAll()
        {
            return _reposotory.GetAll();
        }

        public bool Update(User user)
        {
            return _reposotory.Update(user);
        }
    }
}
