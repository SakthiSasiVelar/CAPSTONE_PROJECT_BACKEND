namespace Toy_Store_Management_Backend.Exceptions
{
    public class OrderItemNotGetException : Exception
    {
        string msg;

        public OrderItemNotGetException(int id)
        {
            msg = "error in getting order item details for id:" + id;
        }

        public override string Message => msg;
    }
}
