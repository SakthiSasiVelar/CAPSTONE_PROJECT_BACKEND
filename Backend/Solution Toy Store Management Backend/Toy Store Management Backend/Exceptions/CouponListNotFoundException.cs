namespace Toy_Store_Management_Backend.Exceptions
{
    public class CouponListNotFoundException : Exception
    {
        string msg;

        public CouponListNotFoundException()
        {
            msg = "error in getting coupon list";
        }

        public override string Message => msg;
    }
}
