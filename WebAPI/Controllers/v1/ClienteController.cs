using Application.Features.Clientes.Commands.CreateClienteComand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace WebAPI.Controllers.v1
{
    //[Route("api/[controller]")] ESTO NO VA PORQUE ESTOY VERSIONANDO MI CONTROLADOR
    // [ApiController]
    [ApiVersion("1.0")]
    public class ClienteController : BaseApiController 
        // EL OBJETIVO DE NUESTRO CONTROLADOR SOLO ES ENRUTAR, NO TENER LOGICA
        // TODA LA LOGICA ESTA EN EL DIRECTORIO CORE
    {
        //POST api/controllers CREAR UN CLIENTE
        [HttpPost]
        public async Task<IActionResult> Post(CreateClienteComand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
