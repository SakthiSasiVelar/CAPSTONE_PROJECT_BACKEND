using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IToyService
    {
        public Task<AddToyReturnDTO> AddToy(AddToyDTO addToyDTO);

        public Task<List<ToyFilterReturnDTO>> FilterByCategory(string categoryName);

        public Task<List<ToyFilterReturnDTO>> FilterByBrand(string  brandName);

        public Task<List<ToyFilterReturnDTO>> FilterByAgeRange(string ageRange);

        public Task<List<ToyFilterReturnDTO>> FilterByArrivalDate();

        public Task<List<ToyFilterReturnDTO>> FilterByMultipleValues(ToyMultipleFilterDTO toyMultipleFilterDTO);

        public Task<AddToyReturnDTO> GetToyDetailsById(int id);

        public Task<List<ToyFilterReturnDTO>> GetToyDetailListByToyId(GetToyDetailListByToyIdDTO getToyDetailByIdDTO);

        public Task<QuantityCheckReturnDTO> QuantityCheck(List<CartItemDTO> cartItemDTOs);

        public Task<List<ToyFilterReturnDTO>> UpdateQuantity(List<CartItemDTO> cartItemDTOs);
    }
}
