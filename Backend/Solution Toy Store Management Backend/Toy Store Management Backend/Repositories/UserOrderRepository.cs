using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class UserOrderRepository : UserRepository
    {
        public UserOrderRepository(ToyStoreManagementDbContext dbContext) : base(dbContext) { }

        public virtual async Task<User> GetById(int id)
        {
            try
            {
                var entity = await _context.Users.Include(user => user.Orders).SingleOrDefaultAsync(user => user.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new UserNotFoundException(id);
            }
            catch (UserNotFoundException)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw new UserNotGetException(id);
            }
        }
    }
}
