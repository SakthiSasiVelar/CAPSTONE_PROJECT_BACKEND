namespace Toy_Store_Management_Backend.Exceptions
{
    public class ReviewNotAddException : Exception
    {
        string msg;

        public ReviewNotAddException()
        {
            msg = "error in adding the review details";
        }

        public override string Message => msg;
    }
}
