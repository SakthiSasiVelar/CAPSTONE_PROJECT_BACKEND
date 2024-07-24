namespace Toy_Store_Management_Backend.Exceptions
{
    public class CartItemNotGetException : Exception
    {
        string msg;

        public CartItemNotGetException(int id)
        {
            msg = "error in getting cart item for id:" + id;
        }

        public override string Message => msg;
    }
}
