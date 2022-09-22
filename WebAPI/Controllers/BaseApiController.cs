using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers
{
    
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")] // VERSIONAR NUESTROS CONTROLADORES
    public abstract class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        // HACEMOS UNA INYECCION DIRECTA DEL MEDIATOR PARA QUE 
        // CUALQUIER COSA QUE HEREDE DE BaseApiController LO PUEDAS IMPLEMENTAR EN UN CONTROLADOR
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
