using LAB_API.Interfaces;
using LAB_API.Model;
using LAB_API.Repository.Context;
using System.Data.Entity;

namespace LAB_API.Repository
{
    public class LabRepository : ILabRepository
    {

        private DataBaseContext _context;

        public LabRepository()
        {
            _context = new DataBaseContext();
        }

        public List<Lab> GetAll()
        {
            return _context.Labs.AsNoTracking().ToList();
        }

        public Lab GetLabByLabCode(string code)
        {
            var result = _context.Labs.AsNoTracking().FirstOrDefault(l => l.LabCode == code);
            return result == null ? throw new Exception("Lab was not found") : result;
        }
        public Lab Create(Lab lab)
        {
            try
            {
                _context.Labs.Add(lab);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return GetLabByLabCode(lab.LabCode);
        }

        public Lab Update(Lab lab)
        {
            var updateLab = _context.Labs.FirstOrDefault(l => l.LabCode == lab.LabCode);
            if (updateLab == null) { throw new Exception("Lab was not found"); }

            updateLab.Description = lab.Description;
            updateLab.IsActive = lab.IsActive;

            try
            {
                _context.Labs.Update(updateLab);
                _context.SaveChanges(); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return GetLabByLabCode(lab.LabCode);
        }

        public bool Delete(string code)
        {
            try
            {
                var lab = _context.Labs.FirstOrDefault(l => l.LabCode == code);
                if (lab == null) { throw new Exception("Lab was not found"); }

                _context.Labs.Remove(lab);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
