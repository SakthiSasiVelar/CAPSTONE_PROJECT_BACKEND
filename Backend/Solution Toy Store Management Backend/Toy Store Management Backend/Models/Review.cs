namespace Toy_Store_Management_Backend.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int ToyId { get; set; }  

        public Toy Toy { get; set; }

        public string Ratings { get; set; }

        public string ReviewText { get; set; }

        public DateTime ReviewDateTime { get; set; }
    }
}
