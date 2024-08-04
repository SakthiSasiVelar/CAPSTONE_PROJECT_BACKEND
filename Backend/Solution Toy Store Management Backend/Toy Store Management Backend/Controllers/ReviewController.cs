using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("review/add")]
        [Authorize(Roles = "User")]

        public async Task<ActionResult<AddReviewReturnDTO>>  Add([FromBody]AddReviewDTO addReviewDTO)
        {
            try
            {
                var result = await _reviewService.AddReview(addReviewDTO);
                var response = new SuccessResponseModel<AddReviewReturnDTO>(201, "Review added successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpGet("review/toy/{toyId}")]

        public async Task<ActionResult<List<ReviewReturnDTO>>> GetByToyId(int toyId)
        {
            try
            {
                var result = await _reviewService.GetAllReviewByToyId(toyId);
                var response = new SuccessResponseModel<List<ReviewReturnDTO>>(200 , "toy review list fetched successfully" , result);
                return Ok(response);
            }
            catch (ToyNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }

        }
    }
}
