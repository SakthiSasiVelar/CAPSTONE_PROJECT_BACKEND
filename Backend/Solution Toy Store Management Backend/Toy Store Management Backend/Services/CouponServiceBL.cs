using Toy_Store_Management_Backend.DTOs;
using Toy_Store_Management_Backend.Exceptions;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Mapper;
using Toy_Store_Management_Backend.Models;
using Toy_Store_Management_Backend.Repositories;

namespace Toy_Store_Management_Backend.Services
{
    public class CouponServiceBL : ICouponService
    {
        private readonly IRepository<int, Coupon> _couponRepository;
        private readonly UserOrderRepository _userOrderRepository;

        public CouponServiceBL(IRepository<int, Coupon> couponRepository , UserOrderRepository userOrderRepository)
        {
            _couponRepository = couponRepository;
            _userOrderRepository = userOrderRepository;
        }

        public async Task<CheckCouponCodeReturnDTO> CheckCouponCode(CheckCouponCodeDTO checkCouponCodeDTO)
        {
            try
            {
                var couponList = await _couponRepository.GetAll();
                foreach(var coupon in couponList)
                {
                    if(coupon.CouponCode == checkCouponCodeDTO.CouponCode)
                    {
                        var user = await _userOrderRepository.GetById(checkCouponCodeDTO.UserId);
                        if(user.Orders.Count == 0)
                        {
                            return await new DTOMapper().CouponToCheckCouponCodeReturnDTO(coupon);
                        }
                        throw new NotValidUserToUseCouponCode();
                    }
                }
                throw new InValidCouponCode();
            }
            catch (UserNotFoundException)
            {
                throw;
            }
            catch (NotValidUserToUseCouponCode)
            {
                throw;
            }
            catch (InValidCouponCode)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new Exception("error in validating coupon code");
            }
        }
    }
}
