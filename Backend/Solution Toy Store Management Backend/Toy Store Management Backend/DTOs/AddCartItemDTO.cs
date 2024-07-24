using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.DTOs
{
    public class AddCartItemDTO
    {
        public int UserId { get; set; }

        public int ToyId { get; set; }

        public int Quantity { get; set; }
    }
}
