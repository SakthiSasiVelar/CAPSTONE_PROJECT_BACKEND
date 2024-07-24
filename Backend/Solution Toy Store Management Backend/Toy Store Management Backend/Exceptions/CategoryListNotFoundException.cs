namespace Toy_Store_Management_Backend.Exceptions
{
    public class CategoryListNotFoundException : Exception
    {
        string msg;

        public CategoryListNotFoundException()
        {
            msg = "error in getting category list";
        }

        public override string Message => msg;
    }
}
