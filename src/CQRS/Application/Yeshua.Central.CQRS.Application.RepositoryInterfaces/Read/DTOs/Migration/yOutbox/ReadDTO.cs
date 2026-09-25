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
    public partial record yOutboxDTO
    {
    public int id { get; set; }
    public string messageid { get; set; } = string.Empty;
    public string type { get; set; } = string.Empty;
    public string entitytype { get; set; } = string.Empty;
    public string entityid { get; set; } = string.Empty;
    public string correlationid { get; set; } = string.Empty;
    public string payload { get; set; } = string.Empty;
    public int status { get; set; }
    public int transporttype { get; set; }
    public string transportdata { get; set; } = string.Empty;
    public DateTime createdat { get; set; }
    public DateTime sentat { get; set; }
    public int retrycount { get; set; }
    public string lasterror { get; set; } = string.Empty;
    public DateTime processingat { get; set; }
    public DateTime nextattemptat { get; set; }
    public int sagaid { get; set; }
    public int sagastepid { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration