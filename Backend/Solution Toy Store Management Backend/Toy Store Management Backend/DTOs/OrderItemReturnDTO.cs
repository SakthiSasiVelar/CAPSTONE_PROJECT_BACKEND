namespace Toy_Store_Management_Backend.DTOs
{
    public class OrderItemReturnDTO
    {
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public int ToyId { get; set; }

        public int Quantity { get; set; }

        public string Price { get; set; }

        public string OrderItemStatus { get; set; }

        public DateTime StatusActionDateTime { get; set; }
    }
}
