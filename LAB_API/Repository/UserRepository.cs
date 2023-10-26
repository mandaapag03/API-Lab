using LAB_API.Model;
using LAB_API.Model.Interfaces;
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
        public List<User>? GetAllUsers()
        {
            return _context.Users
                .AsNoTracking()
                .Include(x => x.UserType)
                .ToList();
        }
        public User? GetById(int id)
        {
            return _context.Users
                .AsNoTracking()
                .Include(x => x.UserType)
                .FirstOrDefault(u => u.Id == id);
        }

        public User? Create(User user)
        {
            NullOrEmptyVariable<User>.ThrowIfNull(user, "User is null");
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Could not insert new user.");
            }       
            return _context.Users.Include(u => u.UserType).FirstOrDefault(u => u.CpfCnpj == user.CpfCnpj);
        }

        public User Update(User user, int id = 0)
        {
            if(id > 0)
                user.Id = id;

            var updateUser = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (updateUser == null) { throw new Exception("User was not found"); }
             
            updateUser.Name = user.Name;
            updateUser.Email = user.Email;
            updateUser.Password = user.Password;
            updateUser.Phone = user.Phone;

            try
            {
                _context.Users.Update(updateUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("The user could not be updated");
            }
            
            return GetById(user.Id);
        }

        public User Disable(int id)
        {
            var updateUser = _context.Users.FirstOrDefault(u => u.Id == id);
            if (updateUser == null) { throw new Exception("User was not found"); }

            updateUser.IsActive = false;

            try
            {
                _context.Users.Update(updateUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("The user could not be updated");
            }
            return GetById(id);
        }

        public User Enable(int id)
        {
            var updateUser = _context.Users.FirstOrDefault(u => u.Id == id);
            if (updateUser == null) { throw new Exception("User was not found"); }

            updateUser.IsActive = true;

            try
            {
                _context.Users.Update(updateUser);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("The user could not be updated");
            }
            return GetById(id);
        }

        public User? Login(Credencials credencials)
        {
            var user = _context.Users
                .Include(u => u.UserType)
                .FirstOrDefault(u => u.Email == credencials.Email);

            if(user == null)
                return null;

            if (user.Password != credencials.Password)
                return null;

            return user;
        }
    }
}
