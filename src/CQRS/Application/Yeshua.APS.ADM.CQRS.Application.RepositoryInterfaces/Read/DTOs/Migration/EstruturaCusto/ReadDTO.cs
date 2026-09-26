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
    public partial record EstruturaCustoDTO
    {
    public int est_id { get; set; }
    public int ito_id { get; set; }
    public string ord_id { get; set; } = string.Empty;
    public string pro_id { get; set; } = string.Empty;
    public string pro_id_produto { get; set; } = string.Empty;
    public string pro_id_componente { get; set; } = string.Empty;
    public string pro_tipo_custo { get; set; } = string.Empty;
    public string pro_grupo_contabil { get; set; } = string.Empty;
    public int est_ordem { get; set; }
    public string est_grupo { get; set; } = string.Empty;
    public Decimal est_quant { get; set; }
    public Decimal est_valor_total { get; set; }
    public string est_data_base { get; set; } = string.Empty;
    public Decimal est_base_producao { get; set; }
    public Decimal est_nivel { get; set; }
    public int fpr_seq_repeticao { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration