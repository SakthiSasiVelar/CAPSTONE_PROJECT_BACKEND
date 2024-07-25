namespace Toy_Store_Management_Backend.Exceptions
{
    public class OrderItemNotFoundException : Exception
    {
        string msg;

        public OrderItemNotFoundException(int id)
        {
            msg = "order item not found for id:" + id;
        }

        public override string Message => msg;
    }
}
