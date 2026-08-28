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
    public partial record T_MetasDTO
    {
    public int met_id { get; set; }
    public string met_dtinicio { get; set; }
    public string met_dtfim { get; set; }
    public string met_alvo { get; set; }
    public int met_tipoalvo { get; set; }
    public int ind_id { get; set; }
    public Decimal met_range01 { get; set; }
    public Decimal met_range02 { get; set; }
    public Decimal met_range03 { get; set; }
    public int dim_id { get; set; }
    public string fat_id { get; set; }
    public string dim_subdimensao_id { get; set; }
    public string per_id { get; set; }
    public string dom_empresa { get; set; }
    public string dom_filial { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration