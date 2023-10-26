using LAB_API.Model;

namespace LAB_API.Model.Interfaces
{
    public interface ILabRepository
    {
        List<Lab> GetAll();
        Lab GetLabByLabCode(string code);
        Lab GetLabById(int id);
        Lab Create(Lab lab);
        Lab Update(Lab lab);
        Lab Disable(string code);
        Lab Enable(string code);
    }
}
