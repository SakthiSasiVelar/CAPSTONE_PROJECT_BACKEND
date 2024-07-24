using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Interface
{
    public interface IAuthService
    {
        public Task<UserRegisterReturnDTO> RegisterUser(UserRegisterDTO userRegisterDTO);

        public Task<LoginReturnDTO> Login(LoginDTO loginDTO);


    }
}
