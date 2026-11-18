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
    public partial record CobrancaCreditoDTO
    {
    public string id { get; set; } = string.Empty;
    public Decimal creditos { get; set; }
    public Decimal valor { get; set; }
    public int status { get; set; }
    public DateTime criadaemutc { get; set; }
    public DateTime venceemutc { get; set; }
    public string moeda { get; set; } = string.Empty;
    public string provedor { get; set; } = string.Empty;
    public DateTime pagaemutc { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration