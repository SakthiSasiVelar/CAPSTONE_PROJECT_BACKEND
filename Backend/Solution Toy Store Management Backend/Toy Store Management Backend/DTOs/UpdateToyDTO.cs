namespace Toy_Store_Management_Backend.DTOs
{
    public class UpdateToyDTO
    {
        public int ToyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }

        public string AgeRange { get; set; }

        public string Price { get; set; }

        public string Discount { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public DateTime ArrivalDateTime { get; set; }
    }
}
