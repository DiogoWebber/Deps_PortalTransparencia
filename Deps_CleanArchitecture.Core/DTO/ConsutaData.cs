using System.Collections.Generic;
using Deps_CleanArchitecture.Core.Entities;

namespace Deps_CleanArchitecture.Core.DTO;

public class ConsultaData
{
    public string Documento { get; set; }
    public string Id_Produto { get; set; }
    public string Id_User { get; set; }
    public string Id_Cliente { get; set; }
    public string Id_Provedor { get; set; }
    
    public List<CepimModel> Resposta { get; set; } 
}