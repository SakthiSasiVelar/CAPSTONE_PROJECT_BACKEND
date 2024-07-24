using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Interface;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("brand/addBrand")]
        [ProducesResponseType(typeof(AddBrandReturnDTO) ,StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<AddBrandReturnDTO>> BrandAdd([FromBody]AddBrandDTO addBrandDTO)
        {
            try
            {
                var result = await _brandService.AddBrand(addBrandDTO);
                var response = new SuccessResponseModel<AddBrandReturnDTO>(201, "Brand created successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
