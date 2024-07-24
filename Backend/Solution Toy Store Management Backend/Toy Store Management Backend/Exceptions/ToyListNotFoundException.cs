namespace Toy_Store_Management_Backend.Exceptions
{
    public class ToyListNotFoundException : Exception
    {
        string msg;

        public ToyListNotFoundException()
        {
            msg = "error in getting toy list details";
        }

        public override string Message => msg;
    }
}
