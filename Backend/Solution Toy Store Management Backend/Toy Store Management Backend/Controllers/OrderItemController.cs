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
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }


        [HttpPut("orderItem/updateStatus")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<UpdateOrderItemStatusReturnDTO>> UpdateStatus([FromBody] UpdateOrderItemStatusDTO updateOrderItemStatusDTO)
        {
            try
            {
               
                var result = await _orderItemService.UpdateOrderItemStatus(updateOrderItemStatusDTO);
                var response = new SuccessResponseModel<UpdateOrderItemStatusReturnDTO>(200, "order item status updated successfully", result);
                return Ok(response);
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(new ErrorModel(404 ,ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500 , new ErrorModel(500, ex.Message));
            }
        }

        [HttpPut("orderItem/cancel")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<CancelOrderItemReturnDTO>> Cancel([FromBody] CancelOrderItemDTO cancelOrderItemDTO)
        {
            try
            {
                var result = await _orderItemService.CancelOrderItem(cancelOrderItemDTO);
                var response = new SuccessResponseModel<CancelOrderItemReturnDTO>(200, "order item cancelled successfully", result);
                return Ok(response);
            }
            catch(OrderNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }

        }

        [HttpGet("orderItem/getAll/{userId}")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<List<OrderItemReturnDTO>>> GetAllByUserId(int userId)
        {
            try
            {
                var result = await _orderItemService.GetAllOrderItems(userId);
                var response = new SuccessResponseModel<List<OrderItemReturnDTO>>(200, "order item list fetched successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpGet("orderItem/filter/{status}")]

        public async Task<ActionResult<List<OrderItemReturnDTO>>> Filter(string status)
        {
            try
            {
                var result = await _orderItemService.FilterByStatus(status);
                var response = new SuccessResponseModel<List<OrderItemReturnDTO>>(200, $" {status} order item list fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpGet("orderItem/get/{orderItemId}/{userId}")]
         [Authorize(Roles = "User")]

        public async Task<ActionResult<OrderItemReturnDTO>> Get(int orderItemId , int userId)
        {
            try
            {
                var result = await _orderItemService.GetCartItemById(orderItemId , userId);
                var response = new SuccessResponseModel<OrderItemReturnDTO>(200, " order item  fetched successfully", result);
                return Ok(response);
            }
            catch(NotValidUserToGetOrderItem ex)
            {
                return StatusCode(403 , new ErrorModel(403,ex.Message));
            }
            catch (OrderNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

       [HttpGet("orderItem/getAll")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<List<OrderItemReturnDTO>>> GetAll( )
        {
            try
            {
                var result = await _orderItemService.GetAllOrderItemsList();
                var response = new SuccessResponseModel<List<OrderItemReturnDTO>>(200, "order item list fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
