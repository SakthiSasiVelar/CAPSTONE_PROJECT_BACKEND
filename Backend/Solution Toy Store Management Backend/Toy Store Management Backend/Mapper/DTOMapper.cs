using System.Security.Cryptography;
using System.Text;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Enums;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Mapper
{
    public class DTOMapper
    {
        public async Task<User> UserRegisterDtoToUser(UserRegisterDTO userRegisterDTO)
        {
            User user = new User()
            {
                Name = userRegisterDTO.Name,
                Email = userRegisterDTO.Email,
            };
            return user;
        }

        public async Task<UserAuthDetails> UserRegisterDtoToUserAuthDetails(UserRegisterDTO userRegisterDTO , int userId)
        {
            UserAuthDetails userAuthDetails = new UserAuthDetails()
            {
                Email = userRegisterDTO.Email,
                UserId = userId,
                Role = EnumClass.Role.User.ToString(),
            };
            HMACSHA512 hMACSHA = new HMACSHA512();
            userAuthDetails.PasswordHashKey = hMACSHA.Key;
            userAuthDetails.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDTO.Password));
            return userAuthDetails;
        }

        public async Task<UserRegisterReturnDTO> UserToUserRegisterReturnDTO(User user)
        {
            UserRegisterReturnDTO userRegisterReturnDTO = new UserRegisterReturnDTO()
            {
                UserId = user.Id,
                UserName = user.Name,
                Email = user.Email,
            };

            return userRegisterReturnDTO;
        }

        public async Task<LoginReturnDTO> UserAuthDetailstoLoginReturnDTO(UserAuthDetails userAuthDetails , string token)
        {
            LoginReturnDTO loginReturnDTO = new LoginReturnDTO()
            {
                Email = userAuthDetails.Email,
                UserId = userAuthDetails.UserId,
                Role = userAuthDetails.Role,
                Token = token
            };
            return loginReturnDTO;
        }

        public async Task<Brand> AddBrandDtoToBrand(AddBrandDTO addBrandDTO)
        {
            Brand brand = new Brand()
            {
                Name = addBrandDTO.Name,
            };
            return brand;
        }

        public async Task<AddBrandReturnDTO> BrandToAddBrandReturnDto(Brand brand)
        {
            AddBrandReturnDTO addBrandReturnDTO = new AddBrandReturnDTO()
            {
                BrandId = brand.Id,
                BrandName = brand.Name,
            };
            return addBrandReturnDTO;
        }
    }
}
