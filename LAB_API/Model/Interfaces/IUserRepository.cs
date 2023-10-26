using LAB_API.Model;

namespace LAB_API.Model.Interfaces
{
    public interface IUserRepository
    {
        List<User>? GetAllUsers();
        User? GetById(int id);
        User? Create(User user);
        User? Login(Credencials credencials);
        User Update(User user, int id = 0);
        User Disable(int id);
        User Enable(int id);
    }
}
