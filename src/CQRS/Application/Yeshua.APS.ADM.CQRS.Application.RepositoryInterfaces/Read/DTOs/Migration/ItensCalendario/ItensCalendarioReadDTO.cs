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
    public partial record ItensCalendarioDTO
    {
    public int ica_id { get; set; }
    public DateTime ica_data_de { get; set; }
    public DateTime ica_data_ate { get; set; }
    public string ica_observacao { get; set; }
    public int ica_tipo { get; set; }
    public string urm_id { get; set; }
    public string urn_id { get; set; }
    public int cal_id { get; set; }
    public string maq_id { get; set; }
    public string pro_id { get; set; }
    public int ica_limpesa_maquina { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration