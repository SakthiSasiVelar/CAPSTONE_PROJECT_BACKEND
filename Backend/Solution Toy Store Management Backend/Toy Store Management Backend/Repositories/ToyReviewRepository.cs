using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class ToyReviewRepository : ToyRepository
    {
        public ToyReviewRepository(ToyStoreManagementDbContext dbContext) : base(dbContext)
        {
           
        }

        public override async Task<IEnumerable<Toy>> GetAll()
        {
            try
            {
                return await _dbContext.Toys.Include(x => x.Reviews).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ToyListNotFoundException();
            }
        }

        public override async Task<Toy> GetById(int id)
        {
            try
            {
                var result = await _dbContext.Toys.Include(x => x.Reviews).SingleOrDefaultAsync(x=>x.Id == id);
                if (result != null) return result;
                throw new ToyNotFoundException(id);
            }
            catch (ToyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ToyNotGetException(id);
            }
        }
    }
}
