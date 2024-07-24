namespace Toy_Store_Management_Backend.Models
{
    public class UserAuthDetails
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public byte[] PasswordHashKey { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public byte[] Password { get; set; }

        public string Role { get; set; }
    }
}
