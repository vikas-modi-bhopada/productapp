namespace ProductWebApplication.MVC.Exceptions
{
    public class UserAlreadyExits : ApplicationException
    {
        public UserAlreadyExits()
        {

        }
        public UserAlreadyExits(string msg) : base(msg)
        {

        }
    }
}
