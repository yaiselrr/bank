using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Commands.CreateClienteComand
{
    public class CreateClienteComand: IRequest<Response<int>> // Response se crea en el directorio Wrappers
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
    }

    public class CreateClienteComandHandler : IRequestHandler<CreateClienteComand, Response<int>>
    { // DEVOLVEMOS UN ENTERO PORQUE ESTE VA A SER EL ID QUE VAMOS A INSERTAR CUANDO CREAMOS EL CLIENTE

        private readonly IRepositoryAsync<Cliente> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateClienteComandHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<int>> Handle(CreateClienteComand request, CancellationToken cancellationToken)
        {
            // SE GENERA EL ARCHIVO GENERALPROFILE QUE ESTA EN CORE/APPLICATION/MAPPINGS
            var nuevoRegistro = _mapper.Map<Cliente>(request); // MAPEA TODO LO QUE SE RECIBE DEL CLIENTE
            var data = await _repositoryAsync.AddAsync(nuevoRegistro); //SE CREA EL CLIENTE

            // ESTO ES LA PRUEBA DE LA MODELACION DEL RESPONSE
            return new Response<int>(data.Id, data.Id, data.Id,data.Id);// DEVOLVEMOS EL ID QUE VAMOS A NECESITAR PARA CREAR EL CLIENTE
        }
    }
}
