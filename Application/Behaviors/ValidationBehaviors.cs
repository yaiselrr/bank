using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validator.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                var validationResult = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(context, cancellationToken)));

                // Recolectar los errores
                var failures = validationResult.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                // si has encontrado algun erro
                if (failures.Count != 0)
                {
                    // lanza una excepcion utilizando la clase generica ValidationException
                    throw new Exceptions.ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
