namespace Toy_Store_Management_Backend.Exceptions
{
    public class NotValidUserToGetOrderItem : Exception
    {
        string msg;

        public NotValidUserToGetOrderItem()
        {
            msg = "Not a valid user to get orderItem";
        }

        public override string Message => msg;
    }
}
