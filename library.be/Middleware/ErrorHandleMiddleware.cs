using library.be.BusinessException;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace library.be.Middleware
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                string jsonResult;
                switch (error)
                {
                    case ExceptionHandling e:
                        response.StatusCode = (int)e.StatusCode;
                        jsonResult = JsonSerializer.Serialize(e.ToSerializableObject());
                        break;
                    default:
                        // unhandled error 
                        jsonResult = JsonSerializer.Serialize(new { MessageCode = "Error", error?.Message, StackTrace = error?.StackTrace });
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                await response.WriteAsync(jsonResult);
            }
        }
    }
}
