using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config => 
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // QUE ASUMA POR DEFECTO CUANDO NO ESTA ESPECIFICADA LA VERSION
                config.AssumeDefaultVersionWhenUnspecified = true; 

                config.ReportApiVersions = true;
            });
        }
    }
}
