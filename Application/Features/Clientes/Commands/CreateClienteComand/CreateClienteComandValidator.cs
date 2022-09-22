using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.CreateClienteComand
{
    // IMPLEMENTANDO FLUENT VALIDATION
    public class CreateClienteComandValidator : AbstractValidator<CreateClienteComand>
    {
        public CreateClienteComandValidator()
        {
            // VALIDACION DEL NOMBRE
            RuleFor(p => p.Nombre)
                   .NotEmpty()
                   .WithMessage("{PropertyName} no puede ser vacio")
                   .MaximumLength(80)
                   .WithMessage("{PropertyName} no puede ser exceder de {MaxLength} caracteres");

            // VALIDACION DEL APELLIDO
            RuleFor(p => p.Apellido)
                   .NotEmpty()
                   .WithMessage("{PropertyName} no puede ser vacio")
                   .MaximumLength(80)
                   .WithMessage("{PropertyName} no puede ser exceder de {MaxLength} caracteres");

            // VALIDACION DE FECHA DE NACIMIENTO
            RuleFor(p => p.FechaNacimiento)
                   .NotEmpty()
                   .WithMessage("Fecha de nacimiento no puede ser vacio");

            // VALIDACION DEL TELEFONO
            RuleFor(p => p.Telefono)
                   .NotEmpty()
                   .WithMessage("{PropertyName} no puede ser vacio")
                   .Matches(@"^\d{4}-\d{4}$")
                   .WithMessage("{PropertyName} debe cumplir el formato 0000-0000");

            // VALIDACION DEL EMAIL
            RuleFor(p => p.Email)
                   .NotEmpty()
                   .WithMessage("{PropertyName} no puede ser vacio")
                   .EmailAddress()
                   .WithMessage("{PropertyName} debe ser una direccion de email valida")
                   .MaximumLength(100)
                   .WithMessage("{PropertyName} no puede ser exceder de {MaxLength} caracteres");

            // VALIDACION DE LA DIRECCION
            RuleFor(p => p.Direccion)
                   .NotEmpty()
                   .WithMessage("{PropertyName} no puede ser vacio")
                   .MaximumLength(120)
                   .WithMessage("{PropertyName} no puede ser exceder de {MaxLength} caracteres");

        }

    }
}
