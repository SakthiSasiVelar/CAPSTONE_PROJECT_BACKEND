namespace Toy_Store_Management_Backend.Exceptions
{
    public class QuantityMoreThanStockException : Exception
    {
        string msg;

        public QuantityMoreThanStockException()
        {
            msg = "Can add more than in stock";

        }

        public override string Message => msg;
    }
}
