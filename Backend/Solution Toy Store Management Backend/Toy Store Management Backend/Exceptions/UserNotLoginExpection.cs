namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserNotLoginExpection : Exception
    {
        string msg;

        public UserNotLoginExpection()
        {
            msg = "error during login the user";
        }

        public override string Message => msg;
    }
}
