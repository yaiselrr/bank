using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    // ESTA CLASE RESPONSE ES UNA CLASE GENERICA PARA DARLE FORMATO BONITO A NUESTRAS RESPUESTAS APIS
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;

        }

        public Response(T datosComunesRespuestaP, T sociedad, T pazYSalvoCSS, T pazYSalvoDGI,  string message = null)
        {
            Succeeded = true;
            Message = message;

            datosComunesRespuesta = datosComunesRespuestaP;
            Sociedad = sociedad;
            PazYSalvoCSS = pazYSalvoCSS;
            PazYSalvoDGI = pazYSalvoDGI;

        }

        public Response(string message)
        {
            Succeeded=false;
            Message = message;

        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T datosComunesRespuesta { get; set; }
        
        public T Sociedad { get; set; }
        public T PazYSalvoCSS { get; set; }
        public T PazYSalvoDGI { get; set; }
        public T Data { get; set; }

    }
}
