namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserAuthDetailsNotAddException : Exception
    {
        string msg;

        public UserAuthDetailsNotAddException()
        {
            msg = "error in adding user auth details";
        }

        public override string Message => msg;
    }
}
