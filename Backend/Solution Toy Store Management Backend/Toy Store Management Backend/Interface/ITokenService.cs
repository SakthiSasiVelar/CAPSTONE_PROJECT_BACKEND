using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Interface
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(UserAuthDetails userAuthDetails , User user);
    }
}
