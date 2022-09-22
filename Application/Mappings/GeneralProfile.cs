using Application.Features.Clientes.Commands.CreateClienteComand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile 
    {
        public GeneralProfile()
        {
            #region Commands
            // VAMOS A IR AGRUPANDO TODOS LOS COMANDOS DE MAPEO, COMO UN AGRUPADOR
            CreateMap<CreateClienteComand, Cliente>();// ESTO LO QUE VA HACER ES HACERME UN MAPEO DE TODAS LAS PROPIEDADES DEL CLIENTE QUE ESTAN EN EL CREATECLIENTECOMMMAND
            #endregion

        }

    }
}
