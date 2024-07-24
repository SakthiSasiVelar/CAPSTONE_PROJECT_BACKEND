namespace Toy_Store_Management_Backend.Exceptions
{
    
    public class EmailAlreadyTakenException : Exception
    {
        string messsage = string.Empty;

        public EmailAlreadyTakenException()
        {
            messsage = "The email address is already Taken";
        }

        public override string Message => messsage;
    }
}
