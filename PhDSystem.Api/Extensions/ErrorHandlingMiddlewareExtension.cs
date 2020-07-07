using Microsoft.AspNetCore.Builder;
using PhDSystem.Api.Middlewares;

namespace PhDSystem.Api.Extensions
{
    public static  class ErrorHandlingMiddlewareExtension
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
