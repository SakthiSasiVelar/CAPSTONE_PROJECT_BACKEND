using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;

namespace Toy_Store_Management_Backend.Controllers
{
    [Route("api")]
    [EnableCors("MyCors")]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet("coupon/valid/firstOrder")]

        public async Task<ActionResult<CheckCouponCodeReturnDTO>> ValidCoupon([FromBody]CheckCouponCodeDTO checkCouponCodeDTO)
        {
            try
            {
                var result = await _couponService.CheckCouponCode(checkCouponCodeDTO);
                var response = new SuccessResponseModel<CheckCouponCodeReturnDTO>(200, "Coupon validated successfully", result);
                return Ok(response);
            }
            catch(NotValidUserToUseCouponCode ex)
            {
                return StatusCode(600, new ErrorModel(600, ex.Message));
            }
            catch(InValidCouponCode ex)
            {
                return StatusCode(601 , new ErrorModel(601 , ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorModel(500, ex.Message));
            }
        }
    }
}
