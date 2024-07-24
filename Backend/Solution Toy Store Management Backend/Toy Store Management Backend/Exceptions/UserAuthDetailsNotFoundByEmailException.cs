namespace Toy_Store_Management_Backend.Exceptions
{
    public class UserAuthDetailsNotFoundByEmailException : Exception
    {
        string msg;

        public UserAuthDetailsNotFoundByEmailException(string email)
        {
            msg = "user auth details not found for the emai id:" + email;
        }

        public override string Message => msg;
    }
}
