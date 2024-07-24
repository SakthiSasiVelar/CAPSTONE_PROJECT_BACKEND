namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserNotGetException : Exception
    {
        string msg;

        public UserNotGetException(int id)
        {
            msg = "error in getting user details for id:"+id;
        }

        public override string Message => msg;
    }
}
