namespace Toy_Store_Management_Backend.Exceptions
{
    public class InValidCouponCode : Exception
    {
        string msg;

        public InValidCouponCode() {
            msg = "Invalid coupon code";
        }

        public override string Message => msg;
    }
}
