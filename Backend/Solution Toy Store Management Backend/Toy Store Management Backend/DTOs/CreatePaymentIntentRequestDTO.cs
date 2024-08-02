namespace Toy_Store_Management_Backend.DTOs
{
    public class CreatePaymentIntentRequestDTO
    {
        public long Amount { get; set; }
        public string Currency { get; set; }
    }
}
