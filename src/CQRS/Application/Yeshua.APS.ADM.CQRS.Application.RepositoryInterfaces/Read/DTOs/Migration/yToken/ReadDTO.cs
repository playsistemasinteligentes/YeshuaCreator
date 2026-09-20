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
    public partial record yTokenDTO
    {
    public int id { get; set; }
    public string tokenhash { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public string connectorkey { get; set; } = string.Empty;
    public bool active { get; set; }
    public DateTime validuntil { get; set; }
    public DateTime createdat { get; set; }
    public DateTime lastusedat { get; set; }
    public int tenantid { get; set; }
    public int userid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration