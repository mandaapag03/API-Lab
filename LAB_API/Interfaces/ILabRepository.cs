using LAB_API.Model;

namespace LAB_API.Interfaces
{
    public interface ILabRepository
    {
        List<Lab> GetAll();
        Lab GetLabByLabCode(string code);
        Lab Create(Lab lab);
        Lab Update(Lab lab);
        bool Delete(string code);
    }
}
