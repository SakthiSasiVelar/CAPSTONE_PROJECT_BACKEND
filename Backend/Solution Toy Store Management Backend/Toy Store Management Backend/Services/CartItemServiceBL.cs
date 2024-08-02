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
        private readonly ICartItemRepository<int, CartItem> _cartItemRepository;
        private readonly IRepository<int, Toy> _toyRepository;

        public CartItemServiceBL(ICartItemRepository<int, CartItem> cartItemRepository , IRepository<int,Toy> toyRepository)
        {
            _cartItemRepository = cartItemRepository;
            _toyRepository = toyRepository;
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

        public async Task<List<CartItemReturnDTO>> DeleteCartItemByIdList(List<int> cartItemIdList)
        {
            try
            {
                var resut = await _cartItemRepository.DeleteByListId(cartItemIdList);
                return await new DTOMapper().CartItemListToCartItemReturnDTOList(resut.ToList());
            }
            catch(Exception ex)
            {
                throw new Exception("Error in deleting the car items ");
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
                var oldCartItem = await _cartItemRepository.GetById(cartItem.Id);
                if(oldCartItem.Quantity < cartItem.Quantity)
                {
                    var toy = await _toyRepository.GetById(cartItem.ToyId);
                    if(toy.Quantity < cartItem.Quantity)
                    {
                        throw new QuantityMoreThanStockException();
                    }
                }
                var result = await _cartItemRepository.Update(cartItem);
                return await new DTOMapper().CartItemToUpdateCartItemReturnDTO(result);
            }
            catch (QuantityMoreThanStockException)
            {
                throw;
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
