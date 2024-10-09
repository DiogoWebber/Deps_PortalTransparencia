using System.Dynamic;
using System.Net;

namespace Deps_CleanArchitecture.Core.DTO
{
    public class ResponseGenerico<T> where T : class
    {
        public HttpStatusCode CodigoHttp { get; set; }
        
        public T? DadosRetorno { get; set; }
        
        public ExpandoObject? ErroRetorno { get; set; } // Correção: adicionar a chave de fechamento
    }
}