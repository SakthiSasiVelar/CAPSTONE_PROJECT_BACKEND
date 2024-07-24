namespace Toy_Store_Management_Backend.Exceptions
{
    public class CartItemsNotDeleteException : Exception
    {
        string msg;

        public CartItemsNotDeleteException()
        {
            msg = "error in deleting the cart Items";
        }

        public override string Message => msg;
    }
}
