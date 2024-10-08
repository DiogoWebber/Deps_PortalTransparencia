using System.Text.Json.Serialization;

namespace Deps_CleanArchitecture.Core.Entities;

public class CepimModel
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        
        [JsonPropertyName("dataReferencia")]
        public string? DataReferencia { get; set; }
        
        [JsonPropertyName("motivo")]
        public string? Motivo { get; set; }
        
        [JsonPropertyName("orgaoSuperior")]
        public OrgaoSuperior? OrgaoSuperior { get; set; }
        
        [JsonPropertyName("pessoaJuridica")]
        public PessoaJuridica? PessoaJuridica { get; set; }
        
        [JsonPropertyName("convenio")]
        public Convenio? Convenio { get; set; }
    }

    public class OrgaoSuperior
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }
        
        [JsonPropertyName("codigoSIAFI")]
        public string? CodigoSIAFI { get; set; }
        
        [JsonPropertyName("cnpj")]
        public string? Cnpj { get; set; }
        
        [JsonPropertyName("sigla")]
        public string? Sigla { get; set; }
        
        [JsonPropertyName("descricaoPoder")]
        public string? DescricaoPoder { get; set; }
        
        [JsonPropertyName("orgaoMaximo")]
        public OrgaoMaximo? OrgaoMaximo { get; set; }
    }

    public class OrgaoMaximo
    {
        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }
        
        [JsonPropertyName("sigla")]
        public string? Sigla { get; set; }
        
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }
    }

    public class PessoaJuridica
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        
        [JsonPropertyName("cpfFormatado")]
        public string? CPFFormatado { get; set; }
        
        [JsonPropertyName("cnpjFormatado")]
        public string? CNPJFormatado { get; set; }
        
        [JsonPropertyName("numeroInscricaoSocial")]
        public string? NumeroInscricaoSocial { get; set; }
        
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }
        
        [JsonPropertyName("razaoSocialReceita")]
        public string? RazaoSocialReceita { get; set; }
        
        [JsonPropertyName("nomeFantasiaReceita")]
        public string? NomeFantasiaReceita { get; set; }
        
        [JsonPropertyName("tipo")]
        public string? Tipo { get; set; }
    }

    public class Convenio
    {
        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }
        
        [JsonPropertyName("objeto")]
        public string? Objeto { get; set; }
        
        [JsonPropertyName("numero")]
        public string? Numero { get; set; }
    }