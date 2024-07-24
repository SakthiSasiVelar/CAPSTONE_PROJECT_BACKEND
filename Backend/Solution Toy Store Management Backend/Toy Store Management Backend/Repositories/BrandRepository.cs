using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class BrandRepository : IRepository<int, Brand>
    {
        private readonly ToyStoreManagementDbContext _context;

        public BrandRepository(ToyStoreManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> Add(Brand entity)
        {
            try
            {
                _context.Brands.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new BrandNotAddException();
            }
        }

        public Task<Brand> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Brand>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Brand> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Brand> Update(Brand entity)
        {
            throw new NotImplementedException();
        }
    }
}
