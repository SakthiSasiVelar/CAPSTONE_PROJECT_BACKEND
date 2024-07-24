using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Repositories
{
    public class CategoryRepository : IRepository<int, Category>
    {
        private readonly ToyStoreManagementDbContext _dbContext;

        public CategoryRepository(ToyStoreManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> Add(Category entity)
        {
            try
            {
                _dbContext.Categories.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw new CategoryNotAddException();
            }
        }

        public Task<Category> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                return await _dbContext.Categories.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new CategoryListNotFoundException();
            }
        }

        public Task<Category> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
