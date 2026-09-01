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
    public partial record ItensOrcamentoDTO
    {
    public int id { get; set; }
    public int ito_id { get; set; }
    public int orc_id { get; set; }
    public int tip_id { get; set; }
    public string pro_id { get; set; }
    public string ito_obs { get; set; }
    public Decimal ito_quantidade { get; set; }
    public Decimal ito_custo { get; set; }
    public Decimal ito_margem { get; set; }
    public Decimal ito_valor_unitario { get; set; }
    public DateTime ito_verssao_custo { get; set; }
    public string ito_status { get; set; }
    public Decimal ito_erp_custos_fixos { get; set; }
    public Decimal ito_erp_custos_variaveis { get; set; }
    public Decimal ito_erp_despesas_var_venda { get; set; }
    public Decimal ito_erp_impostos { get; set; }
    public string grp_id_composicao { get; set; }
    public Decimal ito_largura { get; set; }
    public Decimal ito_comprimento { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration