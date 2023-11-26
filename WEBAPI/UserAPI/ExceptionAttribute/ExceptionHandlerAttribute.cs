using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductWebApplication.MVC.Exceptions;


namespace ProductWebApplication.MVC.ExceptionAttribute
{
    public class ExceptionHandlerAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType()==typeof(UserCredentialInvalidException))
            {
                context.Result = new OkObjectResult(context.Exception.Message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }
            if (context.Exception.GetType() == typeof(UserAlreadyExits))
            {
                context.Result = new OkObjectResult(context.Exception.Message);
            }
            else
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}
