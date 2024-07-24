namespace Toy_Store_Management_Backend.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ToyId { get; set; }

        public Toy Toy { get; set; }

        public int Quantity { get; set; }
    }
}
