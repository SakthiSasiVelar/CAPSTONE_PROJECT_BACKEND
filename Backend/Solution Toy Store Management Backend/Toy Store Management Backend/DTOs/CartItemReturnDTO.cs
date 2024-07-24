namespace Toy_Store_Management_Backend.DTOs
{
    public class CartItemReturnDTO
    {
        public int CartItemId { get; set; }

        public int UserId { get; set; }

        public int ToyId { get; set; }

        public int Quantity { get; set; }
    }
}
