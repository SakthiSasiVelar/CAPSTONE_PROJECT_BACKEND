namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserNotAddException : Exception
    {
        string msg;

        public UserNotAddException()
        {
            msg = "error in adding the user details";
        }

        public override string Message => msg;
    }
}
