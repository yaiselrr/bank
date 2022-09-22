using Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{

    /* Esta clase va a permitir agrupar las inyecciones o matriculas de nuestros servicios, de terceros o 
     * los propios que hagamos nosotros Ctrl + R + G para desaparcer los using innecesarios*/
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services) {

            // Permiten que se registren automaticamente los mapeos que se hagan en esta biblioteca de clases
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // ACTIVA NUESTRO FLUENT VALIDATION
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            // ACTIVA MEDIATOR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // ACTIVA EL PIPELINE, SIN ESTA LINEA NO VA A FUNCIONR NUESTRO VALIDATOR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
