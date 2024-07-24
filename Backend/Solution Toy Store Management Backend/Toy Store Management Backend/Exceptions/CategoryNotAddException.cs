namespace Toy_Store_Management_Backend.Exceptions
{
    public class CategoryNotAddException : Exception
    {
        string msg;

        public CategoryNotAddException( )
        {
            msg = "error in adding category details";
        }

        public override string Message => msg;
    }
}
