using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi_Handson3.Filters
{
    public class CustomExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string exceptionDetails =
                $"Date: {DateTime.Now}\n" +
                $"Message: {context.Exception.Message}\n" +
                $"Stack Trace: {context.Exception.StackTrace}\n" +
                "------------------------------------------\n";

            string filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "ExceptionLog.txt"
            );

            File.AppendAllText(filePath, exceptionDetails);

            context.Result = new ObjectResult(new
            {
                Message = context.Exception.Message,
                Status = "Internal Server Error"
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}