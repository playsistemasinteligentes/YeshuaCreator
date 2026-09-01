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
    public partial record PlanoacaoDTO
    {
    public int pla_id { get; set; }
    public string pla_descricao { get; set; }
    public int met_id { get; set; }
    public string pla_status { get; set; }
    public DateTime pla_data { get; set; }
    public string pla_metaperiodo { get; set; }
    public string pla_vlrperiodo { get; set; }
    public string pla_metaculado { get; set; }
    public string pla_vlracumulado { get; set; }
    public string pla_referencia { get; set; }
    public int use_id { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration