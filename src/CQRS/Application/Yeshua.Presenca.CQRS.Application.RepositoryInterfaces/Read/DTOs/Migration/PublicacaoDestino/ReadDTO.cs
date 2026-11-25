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
    public partial record PublicacaoDestinoDTO
    {
    public string id { get; set; } = string.Empty;
    public string identidadeid { get; set; } = string.Empty;
    public string versaoid { get; set; } = string.Empty;
    public string canalid { get; set; } = string.Empty;
    public string estado { get; set; } = string.Empty;
    public int tentativas { get; set; }
    public DateTime proximatentativautc { get; set; }
    public string reciboexterno { get; set; } = string.Empty;
    public string urlpublica { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    public string codigoerro { get; set; } = string.Empty;
    public string naturezafalha { get; set; } = string.Empty;
    public bool retrypossivel { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration