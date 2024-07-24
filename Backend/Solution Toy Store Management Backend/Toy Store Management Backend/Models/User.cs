namespace Toy_Store_Management_Backend.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public UserAuthDetails UserAuthDetails { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        public ICollection<Payment> Payments { get; set; }
    }
}
