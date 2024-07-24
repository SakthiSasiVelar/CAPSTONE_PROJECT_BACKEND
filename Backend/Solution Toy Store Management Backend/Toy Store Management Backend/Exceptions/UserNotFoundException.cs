namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserNotFoundException : Exception
    {
        string msg;

        public UserNotFoundException(int id) {
            msg = "user not found for id:" + id;
        }

        public override string Message => msg;
    }
}
