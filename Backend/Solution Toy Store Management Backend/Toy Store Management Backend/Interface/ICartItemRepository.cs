namespace Toy_Store_Management_Backend.Interface
{
    public interface ICartItemRepository<K,T> where T : class
    {
        public Task<T> Add(T entity);
        public Task<T> GetById(K id);
        public Task<T> Update(T entity);
        public Task<T> Delete(K id);
        public Task<List<T>> DeleteByListId (List<K> id);
        public Task<IEnumerable<T>> GetAll();
    }
}
