namespace Toy_Store_Management_Backend.Exceptions
{
    public class OrderNotAddException : Exception
    {
        string msg;

        public OrderNotAddException()
        {
            msg = "error in adding the order details";
        }

        public override string Message => msg;
    }
}
