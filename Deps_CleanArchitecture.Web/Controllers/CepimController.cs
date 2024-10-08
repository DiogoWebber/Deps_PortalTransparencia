using System.Net;
using System.Threading.Tasks;
using Deps_CleanArchitecture.Core.DTO;
using Deps_CleanArchitecture.Core.Interfaces;
using Deps_CleanArchitecture.SharedKernel.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deps_CleanArchitecture.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CepimController : ControllerBase
{
    private readonly ICepimService _CepimService;

    public CepimController(ICepimService cepimService){
        _CepimService = cepimService;
    }

    [HttpGet("busca/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> BuscarCepim([FromQuery] ConsultaData pesquisa)
    {
        if (!ValidadeCNPJ.IsValid(pesquisa.Documento))
        {
            return BadRequest("CNPJ inválido.");
        }

        var response = await _CepimService.BuscarCepim(pesquisa.Documento);

        if (response.CodigoHttp == HttpStatusCode.OK)
        {
            return Ok(response.DadosRetorno);
        }
        else
        {
            return StatusCode((int)response.CodigoHttp, response.ErroRetorno);
        }
    }
}