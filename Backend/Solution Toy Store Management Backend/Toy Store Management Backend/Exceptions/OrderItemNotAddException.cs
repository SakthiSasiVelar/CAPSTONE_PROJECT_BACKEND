namespace Toy_Store_Management_Backend.Exceptions
{
    public class OrderItemNotAddException : Exception
    {
        string msg;

        public OrderItemNotAddException()
        {
            msg = "error in adding the order item details";
        }

        public override string Message => msg;
    }
}
