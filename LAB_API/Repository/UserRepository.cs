using LAB_API.Interfaces;
using LAB_API.Model;
using LAB_API.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace LAB_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _context;

        public UserRepository()
        {
            _context = new DataBaseContext();
        }

        /// <summary>
        /// Sign in new user
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="Exception"></exception>
        public void Create(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Could not insert new user.");
            }
        }

        public User DisableUser(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.AsNoTracking().ToList();
            return users;
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
