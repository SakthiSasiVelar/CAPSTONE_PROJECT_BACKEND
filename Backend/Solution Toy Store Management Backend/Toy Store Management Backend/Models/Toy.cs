namespace Toy_Store_Management_Backend.Models
{
    public class Toy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int BrandId { get; set; }

        public Brand Brand { get; set; }

        public string AgeRange { get; set; }

        public string Price { get; set; }

        public string Discount { get; set; }

        public DateTime ArrivalDate { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<OrderItem> Orders { get; set; }

        public ICollection<CartItem> Carts { get; set; }
    }
}
