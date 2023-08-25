namespace LAB_API.Repository
{
    public interface Repository<T>
    {
        void Create(T entity);
        T Update(T entity);
    }
}
