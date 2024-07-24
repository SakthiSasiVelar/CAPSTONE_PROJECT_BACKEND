namespace Toy_Store_Management_Backend.Exceptions
{
    public class CartItemNotUpdateException : Exception
    {
        string msg;

        public CartItemNotUpdateException()
        {
            msg = "error in updating the cart item";
        }

        public override string Message => msg;
    }
}
