
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class ToyController : ControllerBase
    {
        private readonly IToyService _toyService;

        public ToyController(IToyService toyService)
        {
            _toyService = toyService;
        }

        [HttpPost("toy/add")]

        public async Task<ActionResult<AddToyReturnDTO>> ToyAdd([FromBody] AddToyDTO addToyDTO)
        {
            try
            {
                var result = await _toyService.AddToy(addToyDTO);
                var response = new SuccessResponseModel<AddToyReturnDTO>(201, "toy added successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpGet("toy/filter/category/{categoryName}")]

        public async Task<ActionResult<List<ToyFilterReturnDTO>>> ToyFilterByCategory(string categoryName)
        {
            try
            {
                var result = await _toyService.FilterByCategory(categoryName);
                var response = new SuccessResponseModel<List<ToyFilterReturnDTO>>(200, "Toy List fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }


        [HttpGet("toy/filter/brand/{brandName}")]

        public async Task<ActionResult<List<ToyFilterReturnDTO>>> ToyFilterByBrand(string brandName)
        {
            try
            {
                var result = await _toyService.FilterByBrand(brandName);
                var response = new SuccessResponseModel<List<ToyFilterReturnDTO>>(200, "Toy List fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }


        [HttpGet("toy/filter/ageRange/{ageRange}")]

        public async Task<ActionResult<List<ToyFilterReturnDTO>>> ToyFilterByAgeRange(string ageRange)
        {
            try
            {
                var result = await _toyService.FilterByAgeRange(ageRange);
                var response = new SuccessResponseModel<List<ToyFilterReturnDTO>>(200, "Toy List fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpGet("toy/filter/newArrival")]

        public async Task<ActionResult<List<ToyFilterReturnDTO>>> ToyFilterByNewArrival()
        {
            try
            {
                var result = await _toyService.FilterByArrivalDate();
                var response = new SuccessResponseModel<List<ToyFilterReturnDTO>>(200, "Toy List fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPost("toy/filter")]

        public async Task<ActionResult<List<ToyFilterReturnDTO>>> ToyFilterByMultipleValue([FromBody]ToyMultipleFilterDTO toyMultipleFilterDTO)
        {
            try
            {
                var result = await _toyService.FilterByMultipleValues(toyMultipleFilterDTO);
                var response = new SuccessResponseModel<List<ToyFilterReturnDTO>>(200, "Toy List fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpGet("toy/get/{toyId}")]

        public async Task<ActionResult<AddToyReturnDTO>> getToyById(int toyId)
        {
            try
            {
                var result = await _toyService.GetToyDetailsById(toyId);
                var response = new SuccessResponseModel<AddToyReturnDTO>(200, "Toy details fetched successfully", result);
                return Ok(response);
            }
            catch (ToyNotFoundException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPost("toy/getList")]

        public async Task<ActionResult<List<ToyFilterReturnDTO>>> ToyIdListToToy([FromBody] GetToyDetailListByToyIdDTO getToyDetailByIdDTO)
        {
            try
            {
                var result = await _toyService.GetToyDetailListByToyId(getToyDetailByIdDTO);
                var response = new SuccessResponseModel<List<ToyFilterReturnDTO>>(200, "Toy List fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPost("toy/checkQuantity")]

        public async Task<ActionResult<QuantityCheckReturnDTO>> QuantityCheckForCartItem([FromBody] List<CartItemDTO> cartItemDTOs)
        {
            try
            {
                var result = await _toyService.QuantityCheck(cartItemDTOs);
                var response = new SuccessResponseModel<QuantityCheckReturnDTO>(200, "exceeded quantity toys returned successfully", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPut("toy/updateQuantity")]

        public async Task<ActionResult<List<ToyFilterReturnDTO>>> QuantityUpdate([FromBody] List<CartItemDTO> cartItemDTOs)
        {
            try
            {
                var result = await _toyService.UpdateQuantity(cartItemDTOs);
                var response = new SuccessResponseModel<List<ToyFilterReturnDTO>>(200, "Toy quantity updated successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpGet("toy/getAll")]

        public async Task<ActionResult<List<ToyFilterReturnDTO>>> GetAllToys()
        {
            try
            {
                var result = await _toyService.GetAllToyList();
                var response = new SuccessResponseModel<List<ToyFilterReturnDTO>>(200, "Toy List fetched successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

        [HttpPut("toy/update")]

        public async Task<ActionResult<AddToyReturnDTO>> Update([FromBody]UpdateToyDTO updateToyDTO)
        {
            try
            {
                var result = await _toyService.UpdateToy(updateToyDTO);
                var response = new SuccessResponseModel<AddToyReturnDTO>(200, "toy details updated successfully", result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

    }
}
