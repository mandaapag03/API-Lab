namespace LAB_API.Model.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserTypeRespository
    {
        Task<List<UserType>> GetAll();
        Task<UserType> GetUserType(int id);
    }
}
