using Microsoft.AspNetCore.Http;
using PhDSystem.Api.Models;
using PhDSystem.Data.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PhDSystem.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorDetails errorDetails = GetErrorDetails(ex);
            context.Response.StatusCode = errorDetails.StatusCode;
            context.Response.ContentType = "application/json";

            return context.Response.WriteAsync(errorDetails.ToString());
        }

        private static ErrorDetails GetErrorDetails(Exception ex)
        {
            ErrorDetails errorDetails = new ErrorDetails
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Internal Server Error"
            };

            if (ex is NotFoundException)
            {
                errorDetails.StatusCode = (int)HttpStatusCode.NotFound;
                errorDetails.Message = ex.Message;
            }
            else if (ex is AlreadyExistsException)
            {
                errorDetails.StatusCode = (int)HttpStatusCode.Conflict;
                errorDetails.Message = ex.Message;
            }

            return errorDetails;
        }
    }
}
