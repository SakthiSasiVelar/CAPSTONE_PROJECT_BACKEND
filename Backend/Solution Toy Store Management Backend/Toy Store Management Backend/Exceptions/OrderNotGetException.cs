namespace Toy_Store_Management_Backend.Exceptions
{
    public class OrderNotGetException : Exception
    {
        string msg;

        public OrderNotGetException(int id) {
            msg = "error in getting order details for id:" + id;
        }

        public override string Message => msg;
    }
}
