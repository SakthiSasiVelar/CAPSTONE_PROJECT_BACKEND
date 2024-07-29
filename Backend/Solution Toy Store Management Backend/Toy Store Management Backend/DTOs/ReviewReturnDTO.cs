namespace Toy_Store_Management_Backend.DTOs
{
    public class ReviewReturnDTO
    {
        public int ReviewId { get; set; }

        public int UserId { get; set; }

        public int ToyId { get; set; }

        public string Ratings { get; set; }

        public string ReviewText { get; set; }

        public DateTime ReviewDateTime { get; set; }
    }
}
