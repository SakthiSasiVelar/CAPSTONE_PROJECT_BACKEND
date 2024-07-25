namespace Toy_Store_Management_Backend.Exceptions
{
    public class OrderItemNotUpdateException : Exception
    {
        string msg;

        public OrderItemNotUpdateException()
        {
            msg = "error in updating the order item details";
        }

        public override string Message => msg;
    }
}
