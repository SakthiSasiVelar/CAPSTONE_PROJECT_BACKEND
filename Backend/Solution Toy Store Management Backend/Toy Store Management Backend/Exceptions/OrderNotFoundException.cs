namespace Toy_Store_Management_Backend.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        string msg;

        public OrderNotFoundException(int id) {
            msg = "order not found for id:" + id;
        }

        public override string Message => msg;
    }
}
