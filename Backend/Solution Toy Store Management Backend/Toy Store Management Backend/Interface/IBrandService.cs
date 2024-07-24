using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IBrandService
    {
        public Task<AddBrandReturnDTO> AddBrand(AddBrandDTO addBrandDTO);
    }
}
