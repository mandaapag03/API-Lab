using LAB_API.Model;
using LAB_API.Model.Interfaces;
using LAB_API.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace LAB_API.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserTypeRespository : IUserTypeRespository
    {
        private readonly DataBaseContext _context;

        /// <summary>
        /// 
        /// </summary>
        public UserTypeRespository()
        {
            _context = new DataBaseContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserType>> GetAll()
        {
            return await _context.UserTypes
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserType> GetUserType(int id)
        {
            return NullOrEmptyVariable<UserType>.ThrowIfNull(
                await _context.UserTypes
                .FirstOrDefaultAsync(x => x.Id == id)
                , "User Type not found");
        }
    }
}
