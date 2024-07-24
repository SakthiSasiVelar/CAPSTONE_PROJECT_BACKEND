namespace Toy_Store_Management_Backend.Exceptions
{
    public class CartItemsNotAddException : Exception
    {
        string msg;

        public CartItemsNotAddException()
        {
            msg = "error in adding the cart item";
        }

        public override string Message => msg;
    }
}
