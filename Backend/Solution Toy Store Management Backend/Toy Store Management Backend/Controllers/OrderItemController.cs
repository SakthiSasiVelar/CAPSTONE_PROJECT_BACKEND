﻿using Microsoft.AspNetCore.Cors;
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

        [HttpPost("orderItem/add")]

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

        [HttpGet("orderItem/getAll")]

        public async Task<ActionResult<List<OrderItemReturnDTO>>> GetAll()
        {
            try
            {
                var result = await _orderItemService.GetAllOrderItems();
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
    }
}
