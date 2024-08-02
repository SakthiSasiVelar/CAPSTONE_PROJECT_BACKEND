namespace Toy_Store_Management_Backend.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public string ContactNumber { get; set; }

        public string TotalAmount { get; set; }

        public string Address { get; set; }

        public int Pincode { get; set; }

        public string DeliveryCharge { get; set; }

        public string? SuccessFulPaymentId { get; set; }

        public DateTime OrderDateTime { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
