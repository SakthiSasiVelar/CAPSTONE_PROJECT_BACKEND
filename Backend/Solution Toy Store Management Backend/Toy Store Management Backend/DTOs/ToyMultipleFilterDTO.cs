namespace Toy_Store_Management_Backend.DTOs
{
    public class ToyMultipleFilterDTO
    {
        public int? CategoryId { get; set; }

        public int? BrandId { get; set; }

        public string? AgeRange { get; set; }

        public string? MinPrice { get; set; }

        public string? MaxPrice { get; set;}
    }
}
