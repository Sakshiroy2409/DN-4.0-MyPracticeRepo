using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace WebApi_CustomModels.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            File.WriteAllText("errorlog.txt", context.Exception.ToString());

            context.Result = new ObjectResult("Internal Server Error")
            {
                StatusCode = 500
            };
        }
    }
}