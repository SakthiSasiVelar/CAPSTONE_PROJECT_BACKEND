using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("user/register")]
        [ProducesResponseType(typeof(UserRegisterReturnDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserRegisterReturnDTO>> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            try
            {
                var result = await _authService.RegisterUser(userRegisterDTO);
                var response = new SuccessResponseModel<UserRegisterReturnDTO>(201, "User registered successfully", result);
                return Ok(response);
            }
            catch(EmailAlreadyTakenException ex)
            {
                return Conflict(new ErrorModel(409, ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPost("user/login")]
        [ProducesResponseType(typeof(LoginReturnDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel),StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LoginReturnDTO>> LoginUser([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var result = await _authService.Login(loginDTO);
                var response = new SuccessResponseModel<LoginReturnDTO>(200, "Login successful", result);
                return Ok(response);
            }
            catch (InvalidEmailPasswordException ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }



    }
}
