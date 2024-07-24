using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.DTOs
{
    public class AddToyDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public string AgeRange { get; set; }

        public string Price { get; set; }

        public string Discount { get; set; }
    }
}
