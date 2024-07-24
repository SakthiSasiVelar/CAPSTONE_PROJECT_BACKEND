namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserListNotFoundException : Exception
    {
        string message;

        public UserListNotFoundException()
        {
            message = "error in getting user details";
        }

        public override string Message => message;
    }
}
