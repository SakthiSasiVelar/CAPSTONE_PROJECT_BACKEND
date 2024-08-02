using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class ToyRepository : IRepository<int, Toy>
    {
        protected readonly ToyStoreManagementDbContext _dbContext;

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

        public virtual async Task<IEnumerable<Toy>> GetAll()
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

        public virtual  async Task<Toy> GetById(int id)
        {
            try
            {
                var result = await _dbContext.Toys.SingleOrDefaultAsync(x => x.Id == id);
                if (result != null) return result;
                throw new ToyNotFoundException(id);
            }
            catch (ToyNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new ToyNotGetException(id);
            }
        }

        public async  Task<Toy> Update(Toy entity)
        {
            try
            {
                var existingCartItem = await GetById(entity.Id);
                _dbContext.Entry(existingCartItem).State = EntityState.Detached;
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (ToyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception("error in updating Toy");
            }
        }
    }
}
