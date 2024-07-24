namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserAuthDetailsListNotFoundException : Exception
    {
        string message;

        public UserAuthDetailsListNotFoundException()
        {
            message = "Error in getting user auth details list";
        }

        public override string Message => message;
    }
}
