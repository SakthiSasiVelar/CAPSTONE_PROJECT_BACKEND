using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class UserAuthDetailsRepository : IUserAuthDetailsRepository<int, UserAuthDetails>
    {
        private readonly ToyStoreManagementDbContext _context;

        public UserAuthDetailsRepository(ToyStoreManagementDbContext context)
        {
            _context = context;
        }
        public async Task<UserAuthDetails> Add(UserAuthDetails entity)
        {
            try
            {
                _context.UserAuthDetails.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsNotAddException();
            }
        }

        public Task<UserAuthDetails> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserAuthDetails>> GetAll()
        {
            try
            {
                return await _context.UserAuthDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsListNotFoundException();
            }
        }

        public async Task<UserAuthDetails> GetByEmail(string email)
        {
            try
            {
                var entity = await _context.UserAuthDetails.SingleOrDefaultAsync(user => user.Email == email);
                if (entity != null)
                {
                    return entity;
                }
                throw new UserAuthDetailsNotFoundByEmailException(email);
            }
            catch (UserAuthDetailsNotFoundByEmailException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserAuthDetailsNotGetException();
            }
        }

        public Task<UserAuthDetails> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserAuthDetails> Update(UserAuthDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
