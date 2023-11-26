namespace ProductWebApplication.MVC.Exceptions
{
    public class UserCredentialInvalidException: ApplicationException
    {
        public UserCredentialInvalidException()
        {

        }
        public UserCredentialInvalidException(string msg) : base(msg)
        {

        }
    }
}
