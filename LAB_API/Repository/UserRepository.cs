using LAB_API.Interfaces;
using LAB_API.Model;
using LAB_API.Model.Dto;
using LAB_API.Repository.Context;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

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
            var users = _context.Users.AsNoTracking().ToList();

            List<User> userList = new List<User>();

            foreach (var user in users)
            {
                userList.Add(ConvertUserDtoToUser(user));
            }
            return userList;
        }
        public User? GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            return ConvertUserDtoToUser(user);
        }

        public void Create(User user)
        {
            try
            {
                var newUser = ConvertUserToUserDto(user);
                if(newUser != null)
                {
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                } 
                else
                {
                    throw new Exception("Invalid user: User is not null");
                }
            }
            catch
            {
                throw new Exception("Could not insert new user.");
            }
        }

        public User Update(User user)
        {
            throw new NotImplementedException();
        }

        public User Update(int id, User user)
        {
            throw new NotImplementedException();
        }

        public User DisableUser(User entity)
        {
            throw new NotImplementedException();
        }

        private UserDto ConvertUserToUserDto(User user)
        {
            if (user == null) { throw new ArgumentNullException("Usuário nulo"); }
            UserDto userDto = new UserDto()
            {
                Name = user.Name,
                CpfCnpj = user.CpfCnpj,
                Email = user.Email,
                Phone = user.Phone, 
                Id = user.Id,
                IsActive = user.IsActive,
                Password = user.Password,
                UserTypeId = (int) user.UserType
            };
            return userDto;
        }
        private User ConvertUserDtoToUser(UserDto userDto)
        {
            if(userDto == null) { throw new ArgumentNullException("Usuário nulo"); }
            User user = new User()
            {
                Name = userDto.Name,
                CpfCnpj = userDto.CpfCnpj,
                Email = userDto.Email,
                Phone = userDto.Phone,
                Id = userDto.Id,
                IsActive = userDto.IsActive,
                Password = userDto.Password,
                UserType = (EUserType) userDto.UserTypeId
            };
            return user;
        }

    }
}
