namespace Toy_Store_Management_Backend.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string TotalAmount { get; set; }

        public string Address { get; set; }

        public int Pincode { get; set; }

        public string DeliveryCharge { get; set; }

        public int SuccessFulPaymentId { get; set; }

        public Payment SuccessFulPayment { get; set; }

        public DateTime OrderDateTime { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
