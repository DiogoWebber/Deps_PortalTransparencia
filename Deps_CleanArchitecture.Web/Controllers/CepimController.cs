using System;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Deps_CleanArchitecture.Core.DTO;
using Deps_CleanArchitecture.Core.Interfaces;
using Deps_CleanArchitecture.Core.Mappers;
using Deps_CleanArchitecture.Infrastructure.Data;
using Deps_CleanArchitecture.SharedKernel.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deps_CleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CepimController : ControllerBase
{
    private readonly ICepimService _CepimService;
    private readonly MongoDbContext _MongoDbContext;

    public CepimController(ICepimService cepimService, MongoDbContext mongoDbContext){
        _CepimService = cepimService;
        _MongoDbContext = mongoDbContext;
    }

    [HttpGet("busca/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarCepim([FromQuery] ConsultaCepim pesquisa)
    {
        if (!ValidadeCNPJ.IsValid(pesquisa.Documento))
        {
            return BadRequest("CNPJ inválido.");
        }
        
        
        var response = await _CepimService.BuscarCepim(pesquisa.Documento);

        if (response.CodigoHttp == HttpStatusCode.OK)
        {
            try
            {
                Console.WriteLine("Iniciando o mapeamento dos dados de retorno.");
                var cepimModels = CepimMapper.MapToCepimModelList(response.DadosRetorno);
                
                // Create ConsultaData model with request and response data
                var consultaData = new ConsultaData
                {
                    Documento = pesquisa.Documento,
                    Id_Produto = pesquisa.Id_Produto,
                    Id_User = pesquisa.Id_User,
                    Id_Cliente = pesquisa.Id_Cliente,
                    Id_Provedor = pesquisa.Id_Provedor,
                    Resposta = cepimModels
                };

                // Save ConsultaData model in MongoDB
                Console.WriteLine("Iniciando o salvamento no MongoDB.");
                await _MongoDbContext.SalvarConsulta(consultaData);
                Console.WriteLine("Salvamento concluído.");

                return Ok(response.DadosRetorno);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar os dados no MongoDB: {ex.Message}");
                return StatusCode(500, "Erro ao salvar os dados.");
            }
        }
        else
        {
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }


}