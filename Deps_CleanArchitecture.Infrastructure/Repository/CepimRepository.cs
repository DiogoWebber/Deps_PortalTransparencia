using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.Json;
using Deps_CleanArchitecture.Core.DTO;
using Deps_CleanArchitecture.Core.Entities;
using Deps_CleanArchitecture.Core.Interfaces;

namespace Deps_CleanArchitecture.Infrastructure.Repository {
    public class CepimRepository : ICepimApi{
        
    private readonly HttpClient _httpClient;

    public CepimRepository(HttpClient httpClient) {
        _httpClient = httpClient;
    }

    public async Task<ResponseGenerico<List<CepimModel>>> BuscarCepimPorCnpj(string cnpj) {
            var apiKey = "7c137febe8f79a03ffe7a437026f0e05"; 
            var requestUri =
                $"https://api.portaldatransparencia.gov.br/api-de-dados/cepim?cnpjSancionado={cnpj}&pagina=1";

            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);
            request.Headers.Add("chave-api-dados", apiKey);

            var response = new ResponseGenerico<List<CepimModel>>();

            using (var client = new HttpClient()){
                try
                {
                    var responseBrasilApi = await client.SendAsync(request);
                    var contentResp = await responseBrasilApi.Content.ReadAsStringAsync();
                    
                    if (responseBrasilApi.IsSuccessStatusCode)
                    {
                        try
                        {
                            // Desserializa a resposta como uma lista de CepimModel
                            var objResponse = JsonSerializer.Deserialize<List<CepimModel>>(contentResp);

                            response.CodigoHttp = responseBrasilApi.StatusCode;
                            response.DadosRetorno = objResponse;
                        }
                        catch (JsonException jsonEx)
                        {
                            Console.WriteLine("JSON Deserialization error: " + jsonEx.Message);
                            dynamic erroRetorno = new ExpandoObject();
                            erroRetorno.message = "Erro ao desserializar a resposta.";
                            response.ErroRetorno = erroRetorno;
                        }
                    }
                    else
                    {
                        dynamic erroRetorno = new ExpandoObject();
                        erroRetorno.message = "Erro na API: " + contentResp;
                        response.CodigoHttp = responseBrasilApi.StatusCode;
                        response.ErroRetorno = erroRetorno;
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    Console.WriteLine("HTTP Request error: " + httpEx.Message);
                    response.CodigoHttp = System.Net.HttpStatusCode.ServiceUnavailable;
                    dynamic erroRetorno = new ExpandoObject();
                    erroRetorno.message = "Erro na solicitação HTTP.";
                    response.ErroRetorno = erroRetorno;
                }
            }
            return response;
        }
    }
}
