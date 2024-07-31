using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Services
{
    public class TokenServiceBL : ITokenService
    {
        private readonly string _secretKey;
        private readonly SymmetricSecurityKey _key;

        public TokenServiceBL(IConfiguration configuration)
        {
            _secretKey = configuration["TokenKey:JWT"].ToString();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
        }
        public async Task<string> GenerateToken(UserAuthDetails userAuthDetails , User user)
        {
            string token = string.Empty;
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Email, userAuthDetails.Email.ToString()),
                new Claim(ClaimTypes.Role, userAuthDetails.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier , userAuthDetails.UserId.ToString()),
                new Claim(ClaimTypes.Name , user.Name.ToString())
            };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
            var myToken = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);
            token = new JwtSecurityTokenHandler().WriteToken(myToken);
            return token;
        }
    }
}
