namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserNotDeleteException : Exception
    {
        string msg;

        public UserNotDeleteException(int id)
        {
            msg = "error in deleting user details for id:" + id;
        }

        public override string Message => msg;
    }
}
