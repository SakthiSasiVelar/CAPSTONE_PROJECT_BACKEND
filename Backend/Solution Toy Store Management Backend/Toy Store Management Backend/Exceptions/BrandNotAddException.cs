namespace Toy_Store_Management_Backend.Exceptions
{
    public class BrandNotAddException : Exception
    {
        string msg;

        public BrandNotAddException()
        {
            msg = "error in adding brand";
        }

        public override string Message => msg;
    }
}
