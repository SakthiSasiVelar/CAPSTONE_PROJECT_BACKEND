using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface ICartItemService
    {
        public Task<AddCartItemReturnDTO> AddCartItem(AddCartItemDTO addCartItemDTO);

        public Task<UpdateCartItemReturnDTO> UpdateCartItem(UpdateCartItemDTO updateCartItemDTO);

        public Task<DeleteCartItemReturnDTO> DeleteCartItem(int cartItemId);

        public Task<List<CartItemReturnDTO>> GetCartItemListByUserId(int userId);

        public Task<List<CartItemReturnDTO>> DeleteCartItemByIdList(List<int> cartItemIdList); 
    }
}
