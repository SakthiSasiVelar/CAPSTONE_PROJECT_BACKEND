namespace Toy_Store_Management_Backend.Models
{
    public class OrderItem
    {
        public int Id { get; set; } 

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ToyId { get; set; }  

        public Toy Toy { get; set; } 

        public int Quantity { get; set; }

        public string Price { get; set; }

        public string OrderStatus { get; set; }

        public DateTime StatusActionDateTime { get; set; }

        public string? CancelReason { get; set; }
    }
}
