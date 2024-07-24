namespace Toy_Store_Management_Backend.Exceptions
{
    public class BrandListNotFoundException : Exception
    {
        string msg;

        public BrandListNotFoundException()
        {
            msg = "error in getting brand list";
        }

        public override string Message => msg;
    }
}
