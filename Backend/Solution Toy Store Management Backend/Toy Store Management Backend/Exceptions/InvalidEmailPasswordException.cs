namespace Toy_Store_Management_Backend.Exceptions
{
    public class InvalidEmailPasswordException  :Exception
    {
        string message = string.Empty;

        public InvalidEmailPasswordException()
        {
            message = "Invalid Email and Password";
        }

        public override string Message => message;
    }
}
