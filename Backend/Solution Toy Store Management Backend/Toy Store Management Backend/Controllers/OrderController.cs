using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("order/placeOrder")]

        public async Task<ActionResult<PlaceOrderReturnDTO>> OrderPlace([FromBody] PlaceOrderDTO placeOrderDTO)
        {
            try
            {
                var result = await _orderService.PlaceOrder(placeOrderDTO);
                var response = new SuccessResponseModel<PlaceOrderReturnDTO>(201, "order placed successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }


        [HttpGet("order/get/{orderId}")]

        public async Task<ActionResult<OrderReturnDTO>> GetOrder(int orderId)
        {
            try
            {
                var result = await _orderService.GetOrderById(orderId);
                var response = new SuccessResponseModel<OrderReturnDTO>(200, "order fetched successfully", result);
                return Ok(response);
            }
            catch(OrderNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
        
    }
}
