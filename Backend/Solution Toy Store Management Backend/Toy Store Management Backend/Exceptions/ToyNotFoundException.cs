namespace Toy_Store_Management_Backend.Exceptions
{
    public class ToyNotFoundException : Exception
    {
        string msg;

        public ToyNotFoundException(int id)
        {
            msg = "Toy not found for the id:" + id;
        }

        public override string Message => msg;
    }
}
