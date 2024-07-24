using System.Diagnostics;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Services
{
    public class CartItemServiceBL : ICartItemService
    {
        private readonly IRepository<int, CartItem> _cartItemRepository;

        public CartItemServiceBL(IRepository<int, CartItem> cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<AddCartItemReturnDTO> AddCartItem(AddCartItemDTO addCartItemDTO)
        {
            try
            {
                var cartItem = await new DTOMapper().AddCartItemDtoToCartItem(addCartItemDTO);
                var result = await _cartItemRepository.Add(cartItem);
                return await new DTOMapper().CartItemToAddCartItemReturnDTO(result);
            }
            catch (Exception ex)
            {
                throw new CartItemsNotAddException();
            }
        }

        public async Task<DeleteCartItemReturnDTO> DeleteCartItem(int cartItemId)
        {
            try
            {
                var result = await _cartItemRepository.Delete(cartItemId);
                return await new DTOMapper().CartItemToDeleteCartItemReturnDTO(result);
            }
            catch (CartItemNotFoundException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new CartItemsNotDeleteException();
            }
        }

        public async Task<List<CartItemReturnDTO>> GetCartItemListByUserId(int userId)
        {
            try
            {
                var cartItemList = await _cartItemRepository.GetAll();
                var filteredList = cartItemList.AsQueryable();
                filteredList = filteredList.Where(x => x.UserId == userId);
                return await new DTOMapper().CartItemListToCartItemReturnDTOList(filteredList.ToList());
            }
            catch(Exception ex)
            {
                throw new Exception("error in getting cart item list for user id:" + userId);
            }
        }

        public async Task<UpdateCartItemReturnDTO> UpdateCartItem(UpdateCartItemDTO updateCartItemDTO)
        {
            try
            {
                var cartItem = await new DTOMapper().UpdateCartItemDtoToCartItem(updateCartItemDTO);
                var result = await _cartItemRepository.Update(cartItem);
                return await new DTOMapper().CartItemToUpdateCartItemReturnDTO(result);
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
