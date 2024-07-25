namespace Toy_Store_Management_Backend.Exceptions
{
    public class NotValidUserToUseCouponCode : Exception
    {
        string msg;

        public NotValidUserToUseCouponCode()
        {
            msg = "Not a valid user";
        }

        public override string Message => msg;
    }
}
