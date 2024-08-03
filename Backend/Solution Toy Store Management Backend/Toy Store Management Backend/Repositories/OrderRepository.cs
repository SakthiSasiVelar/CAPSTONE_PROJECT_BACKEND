using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class OrderRepository : IRepository<int, Order>
    {
        private readonly ToyStoreManagementDbContext _dbContext;

        public OrderRepository(ToyStoreManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> Add(Order entity)
        {
            try
            {
                _dbContext.Orders.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new OrderNotAddException();
            }
        }

        public Task<Order> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            try
            {
                return await _dbContext.Orders.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in getting order list ");
            }
        }

        public async Task<Order> GetById(int id)
        {
            try
            {
                var order =  await _dbContext.Orders.SingleOrDefaultAsync(x => x.Id == id);
                if(order != null)
                {
                    return order;
                }
                throw new OrderNotFoundException(id);
            }
            catch (OrderNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new OrderNotGetException(id);
            }
        }

        public Task<Order> Update(Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
