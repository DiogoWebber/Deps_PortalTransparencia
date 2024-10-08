using System.Collections.Generic;
using System.Threading.Tasks;
using Deps_CleanArchitecture.Core.DTO;
using Deps_CleanArchitecture.Core.Interfaces;

namespace Deps_CleanArchitecture.Core.Interfaces;

public class CepimService : ICepimService
{
    private readonly ICepimApi _cepimPubli;

    public CepimService(ICepimApi cepimPublicosApi)
    {
        _cepimPubli = cepimPublicosApi;
    }

     public async Task<ResponseGenerico<List<CepimResponse>>> BuscarCepim(string cnpj){
    // Inicializa a resposta
    var cepimResponse = new ResponseGenerico<List<CepimResponse>>();

    // Chama o método para obter dados
    var cepim = await _cepimPubli.BuscarCepimPorCnpj(cnpj); // Certifique-se de que este retorno é do tipo correto.

    // Verifica se o retorno é nulo
    if (cepim == null)
    {
        return cepimResponse;
    }

    // Mapeia o retorno
    cepimResponse.CodigoHttp = cepim.CodigoHttp;
    cepimResponse.ErroRetorno = cepim.ErroRetorno;

    cepimResponse.DadosRetorno = new List<CepimResponse>();
    
    if (cepim.DadosRetorno != null)
    {
        foreach (var item in cepim.DadosRetorno)
        {
            var cepimResponseItem = new CepimResponse
            {
                Id = item.Id,
                DataReferencia = item.DataReferencia,
                Motivo = item.Motivo,
                OrgaoSuperior = item.OrgaoSuperior != null ? new OrgaoSuperiorResponse
                {
                    Nome = item.OrgaoSuperior.Nome,
                    CodigoSIAFI = item.OrgaoSuperior.CodigoSIAFI,
                    Cnpj = item.OrgaoSuperior.Cnpj,
                    Sigla = item.OrgaoSuperior.Sigla,
                    DescricaoPoder = item.OrgaoSuperior.DescricaoPoder,
                    OrgaoMaximo = item.OrgaoSuperior.OrgaoMaximo != null ? new OrgaoMaximoResponse
                    {
                        Codigo = item.OrgaoSuperior.OrgaoMaximo.Codigo,
                        Sigla = item.OrgaoSuperior.OrgaoMaximo.Sigla,
                        Nome = item.OrgaoSuperior.OrgaoMaximo.Nome
                    } : null
                } : null,
                PessoaJuridica = item.PessoaJuridica != null ? new PessoaJuridicaResponse
                {
                    Id = item.PessoaJuridica.Id,
                    CPFFormatado = item.PessoaJuridica.CPFFormatado,
                    CNPJFormatado = item.PessoaJuridica.CNPJFormatado,
                    NumeroInscricaoSocial = item.PessoaJuridica.NumeroInscricaoSocial,
                    Nome = item.PessoaJuridica.Nome,
                    RazaoSocialReceita = item.PessoaJuridica.RazaoSocialReceita,
                    NomeFantasiaReceita = item.PessoaJuridica.NomeFantasiaReceita,
                    Tipo = item.PessoaJuridica.Tipo
                } : null,
                Convenio = item.Convenio != null ? new ConvenioResponse
                {
                    Codigo = item.Convenio.Codigo,
                    Objeto = item.Convenio.Objeto,
                    Numero = item.Convenio.Numero
                } : null
            };

            cepimResponse.DadosRetorno.Add(cepimResponseItem);
        }
    }

    return cepimResponse;
}

}