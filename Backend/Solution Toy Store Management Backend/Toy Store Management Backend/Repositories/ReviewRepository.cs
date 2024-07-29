using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class ReviewRepository : IRepository<int, Review>
    {
        private readonly ToyStoreManagementDbContext _context;

        public ReviewRepository(ToyStoreManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Review> Add(Review entity)
        {
            try
            {
                _context.Reviews.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new ReviewNotAddException();
            }
        }

        public Task<Review> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Review>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Review> Update(Review entity)
        {
            throw new NotImplementedException();
        }
    }
}
