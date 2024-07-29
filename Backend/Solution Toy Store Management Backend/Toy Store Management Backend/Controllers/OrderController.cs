using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
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

        [HttpPost("order/add")]

        public async Task<ActionResult<AddOrderReturnDTO>> Add([FromBody] AddOrderDTO addOrderDTO)
        {
            try
            {
                var result = await _orderService.AddOrder(addOrderDTO);
                var response = new SuccessResponseModel<AddOrderReturnDTO>(201, "order details added successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
