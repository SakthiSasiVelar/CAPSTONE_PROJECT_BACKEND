using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IOrderItemService
    {
        public Task<AddOrderItemReturnDTO> AddOrderItem(AddOrderItemDTO addOrderItemDTO);

        public Task<UpdateOrderItemStatusReturnDTO> UpdateOrderItemStatus(UpdateOrderItemStatusDTO updateOrderItemStatusDTO );

    }
}
