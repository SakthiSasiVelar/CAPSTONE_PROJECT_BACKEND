using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.DTOs
{
    public class AddOrderReturnDTO
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string TotalAmount { get; set; }

        public string Address { get; set; }

        public int Pincode { get; set; }

        public string DeliveryCharge { get; set; }

        public string? SuccessFulPaymentId { get; set; }

        public DateTime OrderDateTime { get; set; }
    }
}
