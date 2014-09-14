namespace BlogEngine.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        public void Create(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}