using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.DTOs
{
    public class AddOrderItemDTO
    {
        public int OrderId { get; set; }

        public int ToyId { get; set; }

        public int Quantity { get; set; }

        public string Price { get; set; }
 
    }
}
