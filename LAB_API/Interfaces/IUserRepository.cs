using LAB_API.Model;

namespace LAB_API.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetById(int id);
        void Create(User entity);
        User Update(User entity);
        User DisableUser(User entity);
    }
}
