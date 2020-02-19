using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TopCine.Domain.Features.Users;
using TopCine.Infra.ORM.Context;

namespace TopCine.Infra.ORM.Features.Users
{
    public class UserRepository : IUserRepository
    {
        private TopCineProcessContext _context;
        private long _affectedRows = 0;

        public UserRepository(TopCineProcessContext context)
        {
            _context = context;
        }

        public bool Delete(long id)
        {
            var entity = _context.Users.Where(x => x.Id == id).FirstOrDefault();

            _context.Users.Remove(entity);

            // Save changes in database
            var result = _context.SaveChanges();

            return result > _affectedRows;
        }

        public User Get(long id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public IList<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public IList<User> GetAll(int size)
        {
            throw new NotImplementedException();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
        }

        public User Save(User entity)
        {
            var result = _context.Users.Add(entity);

            // Save changes in database
            _context.SaveChanges();

            return result.Entity;
        }

        public bool Update(User entity)
        {
            _context.Users.Update(entity);

            // Save changes in database
            var result = _context.SaveChanges();

            return result > _affectedRows;
        }
    }
}
