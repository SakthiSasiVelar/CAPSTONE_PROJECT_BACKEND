using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Interface;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class BlobController : ControllerBase
    {
        private readonly IBlobService _blobService;

        public BlobController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost("image/upload")]
        public async Task<ActionResult<UploadImageReturnDTO>> UploadImage([FromForm] UploadImageDTO uploadImageDTO)
        {
            try
            {
                if(uploadImageDTO.ImageFile == null || uploadImageDTO.ImageFile.Length == 0)
                {
                    return BadRequest(new ErrorModel(400, "No file uploaded"));
                }
                var result = await _blobService.UploadImageToBlob(uploadImageDTO);
                var response = new SuccessResponseModel<UploadImageReturnDTO>(200, "Image uploaded to Blob succcessfully and image url is fetched", result);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }

    }
}
