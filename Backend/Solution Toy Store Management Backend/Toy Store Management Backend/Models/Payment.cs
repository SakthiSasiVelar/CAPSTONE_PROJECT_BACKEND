namespace Toy_Store_Management_Backend.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Order SuccessFulOrder { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public string? StripePaymentId { get; set; }    
    }
}
