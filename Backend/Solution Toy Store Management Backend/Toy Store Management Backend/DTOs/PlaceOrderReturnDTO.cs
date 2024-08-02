namespace Toy_Store_Management_Backend.DTOs
{
    public class PlaceOrderReturnDTO
    {
        public AddOrderReturnDTO OrderDetails { get; set; }

        public List<AddOrderItemReturnDTO> OrderItemList { get; set; }
    }
}
