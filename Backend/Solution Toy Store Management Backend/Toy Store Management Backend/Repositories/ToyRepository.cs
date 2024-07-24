using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class ToyRepository : IRepository<int, Toy>
    {
        private readonly ToyStoreManagementDbContext _dbContext;

        public ToyRepository(ToyStoreManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Toy> Add(Toy entity)
        {
            try
            {
                _dbContext.Toys.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new ToyNotAddException();
            }
        }

        public Task<Toy> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Toy>> GetAll()
        {
            try
            {
                return await _dbContext.Toys.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new ToyListNotFoundException();
            }
        }

        public Task<Toy> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Toy> Update(Toy entity)
        {
            throw new NotImplementedException();
        }
    }
}
