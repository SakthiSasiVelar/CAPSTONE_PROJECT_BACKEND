﻿using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IOrderItemService
    {
        public Task<AddOrderItemReturnDTO> AddOrderItem(AddOrderItemDTO addOrderItemDTO);

        public Task<UpdateOrderItemStatusReturnDTO> UpdateOrderItemStatus(UpdateOrderItemStatusDTO updateOrderItemStatusDTO);

        public Task<CancelOrderItemReturnDTO> CancelOrderItem(CancelOrderItemDTO cancelOrderItemDTO);

        public Task<List<OrderItemReturnDTO>> GetAllOrderItems();

        public Task<List<OrderItemReturnDTO>> FilterByStatus(string status);

    }
}
