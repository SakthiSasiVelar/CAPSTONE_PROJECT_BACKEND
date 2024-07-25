using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        protected readonly ToyStoreManagementDbContext _context;

        public UserRepository(ToyStoreManagementDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User entity)
        {
            try
            {
                _context.Users.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new UserNotAddException();
            }
        }

        public async Task<User> Delete(int id)
        {
            try
            {
               var entity = await GetById(id);
                _context.Users.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (UserNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserNotDeleteException(id);
            }
        }

        public  async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new UserListNotFoundException();
            }
        }

        public virtual async Task<User> GetById(int id)
        {
            try
            {
                var entity = await _context.Users.SingleOrDefaultAsync(user => user.Id == id);
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

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
