namespace Toy_Store_Management_Backend.Exceptions
{
    public class CartItemNotFoundException : Exception
    {
        string msg;

        public CartItemNotFoundException(int id)
        {
            msg = "cart item not found for id:"+id;
        }

        public override string Message => msg;
    }
}
