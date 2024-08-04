using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpPost("cartItem/add")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<AddCartItemReturnDTO>> CartItemAdd([FromBody]AddCartItemDTO addCartItemDTO)
        {
            try
            {
                var result = await _cartItemService.AddCartItem(addCartItemDTO);
                var response = new SuccessResponseModel<AddCartItemReturnDTO>(201, "cart Item added successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPut("cartItem/update")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<UpdateCartItemReturnDTO>> CartItemUpdate([FromBody] UpdateCartItemDTO updateCartItemDTO)
        {
            try
            {
                var result = await _cartItemService.UpdateCartItem(updateCartItemDTO);
                var response = new SuccessResponseModel<UpdateCartItemReturnDTO>(201, "cart Item updated successfully", result);
                return Ok(response);
            }
            catch(CartItemNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(QuantityMoreThanStockException ex)
            {
                return StatusCode(603 , new ErrorModel(603 , ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpDelete("cartItem/delete/{cartItemId}")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<DeleteCartItemReturnDTO>> CartItemDelete(int cartItemId)
        {
            try
            {
                var result = await _cartItemService.DeleteCartItem(cartItemId);
                var response = new SuccessResponseModel<DeleteCartItemReturnDTO>(200, "cart Item deleted successfully", result);
                return Ok(response);
            }
            catch (CartItemNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpGet("cartItem/get/user/{userId}")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<List<CartItemReturnDTO>>> GetCartItemByUserId(int userId)
        {
            try
            {
                var result = await _cartItemService.GetCartItemListByUserId(userId);
                var response = new SuccessResponseModel<List<CartItemReturnDTO>>(200, "cart item list fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpDelete("cartItem/deleteList")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<List<CartItemReturnDTO>>> DeleteCartByList([FromBody] List<int> cartItemIdList)
        {
            try
            {
                var result = await _cartItemService.DeleteCartItemByIdList(cartItemIdList);
                var response = new SuccessResponseModel<List<CartItemReturnDTO>>(200, "Cart items deleted successsfully", result);
                return Ok(response);

            }
            catch(Exception ex) {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
