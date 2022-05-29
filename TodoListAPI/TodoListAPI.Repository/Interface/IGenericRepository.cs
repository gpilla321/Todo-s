namespace TodoListAPI.Repository.Interface
{
    public interface IGenericRepository<T>
    {
        public Task<T> Insert(T item);
        public Task<T> Update(T item);
        public Task<bool> Delete(int id);
        public Task<T> Get(int id);
        public Task<IList<T>> GetAll();
    }
}
