using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IOrderItemService
    {
        public Task<UpdateOrderItemStatusReturnDTO> UpdateOrderItemStatus(UpdateOrderItemStatusDTO updateOrderItemStatusDTO);

        public Task<CancelOrderItemReturnDTO> CancelOrderItem(CancelOrderItemDTO cancelOrderItemDTO);

        public Task<List<OrderItemReturnDTO>> GetAllOrderItems(int userId);

        public Task<List<OrderItemReturnDTO>> FilterByStatus(string status);

        public Task<OrderItemReturnDTO> GetCartItemById (int id);

    }
}
