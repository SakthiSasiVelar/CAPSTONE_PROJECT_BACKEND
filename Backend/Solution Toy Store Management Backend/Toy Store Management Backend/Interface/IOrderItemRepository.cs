namespace Toy_Store_Management_Backend.Interface
{
    public interface IOrderItemRepository<K ,T> where T : class
    {
        public Task<List<T>> AddRange(List<T> entity);
        public Task<T> GetById(K id);
        public Task<T> Update(T entity);
        public Task<T> Delete(K id);
        public Task<IEnumerable<T>> GetAll();
    }
}
