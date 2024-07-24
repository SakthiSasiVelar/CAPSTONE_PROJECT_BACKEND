namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserAuthDetailsNotGetException : Exception
    {
        string msg;

        public UserAuthDetailsNotGetException()
        {
            msg = "error in getting user auth details";
        }

        public override string Message => msg;
    }
}
