using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;
using Toy_Store_Management_Backend.Repositories;

namespace Toy_Store_Management_Backend.Services
{
    public class AuthServiceBL : IAuthService
    {
        private readonly IRepository<int, User> _userRepository;
        private readonly IUserAuthDetailsRepository<int, UserAuthDetails> _userAuthDetailsRepository;
        private readonly ITokenService _tokenService;

        public AuthServiceBL(IRepository<int, User> userRepository, IUserAuthDetailsRepository<int, UserAuthDetails> userAuthDetailsRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _userAuthDetailsRepository = userAuthDetailsRepository;
            _tokenService = tokenService;
        }

        public async  Task<UserRegisterReturnDTO> RegisterUser(UserRegisterDTO userRegisterDTO)
        {
            User newUser = null;
            UserAuthDetails newUserAuth = null;
            User addedUser = null;
            UserAuthDetails addedUserAuth = null;
            try
            {
                newUser = await new DTOMapper().UserRegisterDtoToUser(userRegisterDTO);
                bool isValidEmail = await IsValidEmail(newUser);
                if (isValidEmail)
                {
                    addedUser = await _userRepository.Add(newUser);
                    newUserAuth = await new DTOMapper().UserRegisterDtoToUserAuthDetails(userRegisterDTO, addedUser.Id);
                    addedUserAuth = await _userAuthDetailsRepository.Add(newUserAuth);
                    return await new DTOMapper().UserToUserRegisterReturnDTO(addedUser);
                }
                else
                {
                    throw new EmailAlreadyTakenException();
                }

            }
            catch (EmailAlreadyTakenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new UserNotRegisterException();
            }
            finally
            {
                if (addedUserAuth == null && addedUser != null)
                {
                    await RevertUserRegister(addedUser.Id);
                }
            }
        }

        public async Task<LoginReturnDTO> Login(LoginDTO loginDTO)
        {
            try
            {
                var userAuthDetails = await _userAuthDetailsRepository.GetByEmail(loginDTO.Email);
                bool isValidPassword = await IsValidPassword(userAuthDetails, loginDTO.Password);
                if (isValidPassword)
                {
                    var user = await _userRepository.GetById(userAuthDetails.UserId);
                    var token = await _tokenService.GenerateToken(userAuthDetails , user );
                    return await new DTOMapper().UserAuthDetailstoLoginReturnDTO(userAuthDetails, token , user.Name);
                }
                throw new InvalidEmailPasswordException();
            }
            catch (UserAuthDetailsNotFoundByEmailException ex)
            {
                throw new InvalidEmailPasswordException();
            }
            catch (InvalidEmailPasswordException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new UserNotLoginExpection();
            }
        }


        private async Task<bool> IsValidEmail(User newUser)
        {
            try
            {
                var listOfUsers = await _userRepository.GetAll();
                foreach (var user in listOfUsers)
                {
                    if (user.Email == newUser.Email) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new UserListNotFoundException();
            }
        }

        private async Task RevertUserRegister(int id)
        {
            try
            {
                await _userRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new UserNotDeleteException(id);
            }
        }

        private async Task<bool> IsValidPassword(UserAuthDetails userAuthDetails, string password)
        {
            HMACSHA512 hMACSHA512 = new HMACSHA512(userAuthDetails.PasswordHashKey);
            var encryptPassword = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(password));
            if (encryptPassword.Length != userAuthDetails.Password.Length) return false;
            for (int i = 0; i < encryptPassword.Length; i++)
            {
                if (encryptPassword[i] != userAuthDetails.Password[i]) return false;
            }
            return true;
        }

    }
}
