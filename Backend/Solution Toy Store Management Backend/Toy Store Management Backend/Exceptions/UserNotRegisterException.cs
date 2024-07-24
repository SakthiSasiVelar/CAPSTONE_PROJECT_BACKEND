namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserNotRegisterException : Exception
    {
        string msg;

        public UserNotRegisterException() {
            msg = "error in registering the user";
        }

        public override string Message => msg;
    }
}
