using Application.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAPI.Middlewares
{
    // HACIENDO MIDDLEWARE
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                // INTERMEDIANDO LA PETICION HTTP
                await _next(context);

            }
            catch (Exception error)
            {
                // VAMOS A MODIFICAR LA RESPUESTA DE ERROR, VAMOS A PERSONALIZARLA
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

                switch (error)
                {
                    case Application.Exceptions.ApiException e: // Core/Exceptions/ApiException
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Application.Exceptions.ValidationException e: // Core/Exceptions/ValidationException
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
