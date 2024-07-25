using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class CouponRepository : IRepository<int, Coupon>
    {
        private readonly ToyStoreManagementDbContext _dbContext;

        public CouponRepository(ToyStoreManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Coupon> Add(Coupon entity)
        {
            try
            {
                _dbContext.Coupons.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new CouponNotAddException();
            }
        }

        public Task<Coupon> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Coupon>> GetAll()
        {
            try
            {
                return await _dbContext.Coupons.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new CouponListNotFoundException();
            }
        }

        public Task<Coupon> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Coupon> Update(Coupon entity)
        {
            throw new NotImplementedException();
        }
    }
}
