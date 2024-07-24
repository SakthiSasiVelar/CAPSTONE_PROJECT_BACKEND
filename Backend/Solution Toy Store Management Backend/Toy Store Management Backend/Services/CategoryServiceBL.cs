using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Services
{
    public class CategoryServiceBL : ICategoryService
    {
        private readonly IRepository<int, Category> _categoryRepository;

        public CategoryServiceBL(IRepository<int, Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<AddCategoryReturnDTO> AddCategory(AddCategoryDTO categoryDTO)
        {
            try
            {
                var category = await new DTOMapper().AddCategoryDtoToCategory(categoryDTO);
                var result = await _categoryRepository.Add(category);
                return await new DTOMapper().CategoryToAddCategoryReturnDTO(result);
            }
            catch(Exception ex)
            {
                throw new CategoryNotAddException();
            }
        }

       
    }
}
