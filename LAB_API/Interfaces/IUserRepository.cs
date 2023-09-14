using LAB_API.Model;
using LAB_API.Model.Dto;

namespace LAB_API.Interfaces
{
    public interface IUserRepository
    {
        List<User>? GetAllUsers();
        User? GetById(int id);
        void Create(User user);
        User Update(User user);
        User Update(int id, User user);
        User DisableUser(User user);
    }
}
