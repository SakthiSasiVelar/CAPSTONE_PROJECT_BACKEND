using Toy_Store_Management_Backend.DTOs;

namespace Toy_Store_Management_Backend.Interface
{
    public interface ICouponService
    {
        public Task<CheckCouponCodeReturnDTO> CheckCouponCode(CheckCouponCodeDTO checkCouponCodeDTO);
    }
}
