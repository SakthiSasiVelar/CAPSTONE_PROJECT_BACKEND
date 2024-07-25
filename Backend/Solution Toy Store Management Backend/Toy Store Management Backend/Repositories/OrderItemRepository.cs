using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class OrderItemRepository : IRepository<int, OrderItem>
    {
        public readonly ToyStoreManagementDbContext _context;

        public OrderItemRepository(ToyStoreManagementDbContext context)
        {
            _context = context;
        }

        public async Task<OrderItem> Add(OrderItem entity)
        {
            try
            {
                _context.OrderItems.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new OrderItemNotAddException();
            }
        }

        public Task<OrderItem> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderItem>> GetAll()
        {
            try
            {
                return await _context.OrderItems.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new OrderItemListNotGetException();
            }
        }

        public async Task<OrderItem> GetById(int id)
        {
            try
            {
                var entity = await _context.OrderItems.SingleOrDefaultAsync(x => x.Id == id);
                if(entity != null)
                {
                    return entity;
                }

                throw new OrderItemNotFoundException(id);
            }
            catch(Exception ex)
            {
                throw new OrderItemNotGetException(id);
            }
        }

        public async Task<OrderItem> Update(OrderItem entity)
        {
            try
            {
                var existingOrderItem = await GetById(entity.Id);
                _context.Entry(existingOrderItem).State = EntityState.Detached;
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (OrderItemNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new OrderItemNotUpdateException();
            }
        }
    }
}
