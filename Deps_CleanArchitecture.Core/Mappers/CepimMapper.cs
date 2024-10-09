using System.Collections.Generic;
using System.Linq;
using Deps_CleanArchitecture.Core.DTO;
using Deps_CleanArchitecture.Core.Entities;

namespace Deps_CleanArchitecture.Core.Mappers
{
    public class CepimMapper
    {
        public static List<CepimModel> MapToCepimModelList(List<CepimResponse> cepimResponses)
        {
            return cepimResponses.Select(response => new CepimModel
            {
                Id = response.Id,
                DataReferencia = response.DataReferencia,
                Motivo = response.Motivo,
                OrgaoSuperior = MapOrgaoSuperior(response.OrgaoSuperior),
                PessoaJuridica = MapPessoaJuridica(response.PessoaJuridica),
                Convenio = MapConvenio(response.Convenio)
            }).ToList();
        }

        private static OrgaoSuperior MapOrgaoSuperior(OrgaoSuperiorResponse? response)
        {
            if (response == null) return null;

            return new OrgaoSuperior
            {
                Nome = response.Nome,
                CodigoSIAFI = response.CodigoSIAFI,
                Cnpj = response.Cnpj,
                Sigla = response.Sigla,
                DescricaoPoder = response.DescricaoPoder,
                OrgaoMaximo = MapOrgaoMaximo(response.OrgaoMaximo)
            };
        }

        private static OrgaoMaximo MapOrgaoMaximo(OrgaoMaximoResponse? response)
        {
            if (response == null) return null;

            return new OrgaoMaximo
            {
                Codigo = response.Codigo,
                Sigla = response.Sigla,
                Nome = response.Nome
            };
        }

        private static PessoaJuridica MapPessoaJuridica(PessoaJuridicaResponse? response)
        {
            if (response == null) return null;

            return new PessoaJuridica
            {
                Id = response.Id,
                CPFFormatado = response.CPFFormatado,
                CNPJFormatado = response.CNPJFormatado,
                NumeroInscricaoSocial = response.NumeroInscricaoSocial,
                Nome = response.Nome,
                RazaoSocialReceita = response.RazaoSocialReceita,
                NomeFantasiaReceita = response.NomeFantasiaReceita,
                Tipo = response.Tipo
            };
        }

        private static Convenio MapConvenio(ConvenioResponse? response)
        {
            if (response == null) return null;

            return new Convenio
            {
                Codigo = response.Codigo,
                Objeto = response.Objeto,
                Numero = response.Numero
            };
        }
    }
}
