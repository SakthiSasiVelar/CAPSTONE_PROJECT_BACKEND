namespace Toy_Store_Management_Backend.Exceptions
{
    public class ToyNotAddException : Exception
    {
        string msg;

        public ToyNotAddException()
        {
            msg = "error in adding toy details";
        }

        public override string Message => msg;
    }
}
