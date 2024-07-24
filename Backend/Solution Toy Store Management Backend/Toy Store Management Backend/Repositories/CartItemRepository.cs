using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class CartItemRepository : IRepository<int, CartItem>
    {
        private readonly ToyStoreManagementDbContext _dbContext;

        public CartItemRepository(ToyStoreManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<CartItem> Add(CartItem entity)
        {
            try
            {
                _dbContext.CartItems.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new CartItemsNotAddException();
            }
        }

        public async Task<CartItem> Delete(int id)
        {
            try
            {
                var entity = await GetById(id);
                _dbContext.CartItems.Remove(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(CartItemNotFoundException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new CartItemsNotDeleteException();
            }
        }

        public async Task<IEnumerable<CartItem>> GetAll()
        {
            try
            {
                return await _dbContext.CartItems.ToListAsync();

            }
            catch(Exception ex)
            {
                throw new CartItemListNotGetException();
            }
        }

        public async Task<CartItem> GetById(int id)
        {
            try
            {
                var entity = await _dbContext.CartItems.SingleOrDefaultAsync(e => e.Id == id);
                if (entity != null)
                {
                    return entity;
                }
                throw new CartItemNotFoundException(id);
            }
            catch (CartItemNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new CartItemNotGetException(id);
            }
        }

        public async Task<CartItem> Update(CartItem entity)
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
            catch (CartItemNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new CartItemNotUpdateException();
            }
        }
    }
}
