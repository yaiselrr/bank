using Microsoft.AspNetCore.Builder;
using WebAPI.Middlewares;

namespace WebAPI.Extensions
{
    public static class AppExtensions
    {
        // LE COLOCAMOS EL MISMO NOMBRE QUE PUSIMOS EN EL FICHERO STARTUP app.UseErrorHandlingMiddleware();
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            // LE PASAMOS LA CLASE MIDDLEWARE QUE CREAMOS WEBAPI/MIDDLEWARES/ERRORHANDLERMIDDLEWARE
            app.UseMiddleware<ErrorHandlerMiddleware>();

        }
    }
}
