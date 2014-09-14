namespace BlogEngine.Models.Repositories
{
    public interface IRepository<T>
    {
        // Standard CRUD operations
        void Create(T entity);
        void Read(int id);
        void Update(T entity);
        void Delete(int id);
    }
}