namespace Toy_Store_Management_Backend.Exceptions
{
    public class ToyNotGetException : Exception
    {
        string msg;

        public ToyNotGetException(int id)
        {
            msg = "error in getting toy details for id:" + id;
        }

        public override string Message => msg;
    }
}
