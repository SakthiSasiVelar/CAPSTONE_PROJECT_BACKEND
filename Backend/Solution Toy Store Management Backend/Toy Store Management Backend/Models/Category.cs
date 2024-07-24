namespace Toy_Store_Management_Backend.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Toy> Toys { get; set; }
    }
}
