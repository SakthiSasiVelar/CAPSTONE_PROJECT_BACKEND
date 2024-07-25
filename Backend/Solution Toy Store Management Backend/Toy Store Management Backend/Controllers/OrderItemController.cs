using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
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

        [HttpPost("orderItem/addOrderItem")]

        public async Task<ActionResult<AddOrderItemReturnDTO>> Add([FromBody]AddOrderItemDTO addOrderItemDTO)
        {
            try
            {
                var result = await _orderItemService.AddOrderItem(addOrderItemDTO);
                var response = new SuccessResponseModel<AddOrderItemReturnDTO>(201, "orderItem created successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPut("orderItem/updateStatus")]

        public async Task<ActionResult<UpdateOrderItemStatusReturnDTO>> UpdateStatus([FromBody] UpdateOrderItemStatusDTO updateOrderItemStatusDTO)
        {
            try
            {
                var result = await _orderItemService.UpdateOrderItemStatus(updateOrderItemStatusDTO);
                var response = new SuccessResponseModel<UpdateOrderItemStatusReturnDTO>(200, "order item status updated successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500 , new ErrorModel(500, ex.Message));
            }
        }
    }
}
