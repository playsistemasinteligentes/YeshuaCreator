// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration
// </yeshua>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record MDFeDTO
    {
    public int id { get; set; }
    public string chaveacesso { get; set; } = string.Empty;
    public int serie { get; set; }
    public int numero { get; set; }
    public string ufcarregamento { get; set; } = string.Empty;
    public string ufdescarregamento { get; set; } = string.Empty;
    public string placaveiculo { get; set; } = string.Empty;
    public DateTime emitidoem { get; set; }
    public DateTime autorizadoem { get; set; }
    public DateTime iniciadoem { get; set; }
    public DateTime encerradoem { get; set; }
    public DateTime canceladoem { get; set; }
    public int situacao { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration