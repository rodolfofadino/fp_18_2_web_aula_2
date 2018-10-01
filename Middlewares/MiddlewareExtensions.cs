using Microsoft.AspNetCore.Builder;

namespace Fiap01.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuLog(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
