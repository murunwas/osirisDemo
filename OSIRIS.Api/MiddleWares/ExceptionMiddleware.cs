using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OSIRIS.Common.Exceptions;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;

namespace OSIRIS.Api.MiddleWares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            //_logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
              //  _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is  UserExistException || exception is CustomException || exception is NotFoundException)
            {

            }
            else
            {
                Log.Error(exception, exception.Message);
            }
           
            return context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(new {
                message=this.Message,
                statusCode=this.StatusCode
            });
        }
    }
}
