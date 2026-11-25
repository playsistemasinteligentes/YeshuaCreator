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
    public partial record ConteudoVersaoDTO
    {
    public string id { get; set; } = string.Empty;
    public string identidadeid { get; set; } = string.Empty;
    public string pautaid { get; set; } = string.Empty;
    public int numero { get; set; }
    public string hash { get; set; } = string.Empty;
    public string estado { get; set; } = string.Empty;
    public string snapshot { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    public int origemrevisao { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration