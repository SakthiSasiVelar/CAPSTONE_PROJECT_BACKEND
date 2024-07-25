namespace Toy_Store_Management_Backend.Exceptions
{
    public class CouponNotAddException : Exception
    {
        string msg;
        public CouponNotAddException()
        {
            msg = "error in adding coupon details";
        }

        public override string Message => msg;
    }
}
