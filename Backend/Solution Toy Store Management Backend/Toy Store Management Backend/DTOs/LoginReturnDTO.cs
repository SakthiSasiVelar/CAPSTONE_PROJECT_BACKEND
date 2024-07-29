namespace Toy_Store_Management_Backend.DTOs
{
    public class LoginReturnDTO
    {
        public string Email { get; set; }

        public int UserId { get; set; }

        public string Token { get; set; }

        public string Role { get; set; }

        public string Name { get; set; }
    }
}
