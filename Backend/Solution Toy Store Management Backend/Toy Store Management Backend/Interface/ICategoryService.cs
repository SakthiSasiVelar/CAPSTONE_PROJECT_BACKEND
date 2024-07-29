using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface ICategoryService
    {
        public Task<AddCategoryReturnDTO> AddCategory(AddCategoryDTO categoryDTO);

        public Task<List<CategoryReturnDTO>> GetAllCategory();
    }
}
