using System.Collections.Generic;
using System.Threading.Tasks;
using Deps_CleanArchitecture.Core.DTO;

namespace Deps_CleanArchitecture.Core.Interfaces;

public interface ICepimService
{
    Task<ResponseGenerico<List<CepimResponse>>> BuscarCepim(string cnpj);
}