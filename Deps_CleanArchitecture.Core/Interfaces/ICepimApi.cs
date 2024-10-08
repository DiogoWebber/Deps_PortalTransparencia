using System.Collections.Generic;
using System.Threading.Tasks;
using Deps_CleanArchitecture.Core.DTO;
using Deps_CleanArchitecture.Core.Entities;

namespace Deps_CleanArchitecture.Core.Interfaces;

public interface ICepimApi
{
    Task<ResponseGenerico<List<CepimModel>>> BuscarCepimPorCnpj(string cnpj);
}