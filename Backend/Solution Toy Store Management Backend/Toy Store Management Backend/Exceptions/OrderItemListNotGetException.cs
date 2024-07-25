namespace Toy_Store_Management_Backend.Exceptions
{
    public class OrderItemListNotGetException : Exception
    {
        string msg;

        public OrderItemListNotGetException()
        {
            msg = "error in getting the order item list";
        }

        public override string Message => msg;
    }
}
