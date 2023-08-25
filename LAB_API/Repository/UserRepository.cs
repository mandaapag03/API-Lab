using LAB_API.Model;
using LAB_API.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace LAB_API.Repository
{
    public class UserRepository : Repository<User>
    {
        private readonly DataBaseContext _context;

        public UserRepository(DataBaseContext context)
        {
            _context = context;
        }
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

        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
