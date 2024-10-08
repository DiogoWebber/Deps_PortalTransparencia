namespace Deps_CleanArchitecture.Core.DTO;

    public class CepimResponse
    {
        public int? Id { get; set; }
        public string? DataReferencia { get; set; }
        public string? Motivo { get; set; }
        public OrgaoSuperiorResponse? OrgaoSuperior { get; set; }
        public PessoaJuridicaResponse? PessoaJuridica { get; set; }
        public ConvenioResponse? Convenio { get; set; }
    }

    public class OrgaoSuperiorResponse
    {
        public string? Nome { get; set; }
        public string? CodigoSIAFI { get; set; }
        public string? Cnpj { get; set; }
        public string? Sigla { get; set; }
        public string? DescricaoPoder { get; set; }
        public OrgaoMaximoResponse? OrgaoMaximo { get; set; }
    }

    public class OrgaoMaximoResponse
    {
        public string? Codigo { get; set; }
        public string? Sigla { get; set; }
        public string? Nome { get; set; }
    }

    public class PessoaJuridicaResponse
    {
        public int? Id { get; set; }
        public string? CPFFormatado { get; set; }
        public string? CNPJFormatado { get; set; }
        public string? NumeroInscricaoSocial { get; set; }
        public string? Nome { get; set; }
        public string? RazaoSocialReceita { get; set; }
        public string? NomeFantasiaReceita { get; set; }
        public string? Tipo { get; set; }
    }

    public class ConvenioResponse
    {
        public string? Codigo { get; set; }
        public string? Objeto { get; set; }
        public string? Numero { get; set; }
    }
