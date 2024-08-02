using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IOrderService
    {
        public Task<PlaceOrderReturnDTO> PlaceOrder(PlaceOrderDTO placeOrderDTO);
    }
}
