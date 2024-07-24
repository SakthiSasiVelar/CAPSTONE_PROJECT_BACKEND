namespace Toy_Store_Management_Backend.Exceptions
{
    public class CartItemListNotGetException : Exception
    {
        string msg;

        public CartItemListNotGetException()
        {
            msg = "error in getting cart item list";
        }

        public override string Message => msg;
    }
}
