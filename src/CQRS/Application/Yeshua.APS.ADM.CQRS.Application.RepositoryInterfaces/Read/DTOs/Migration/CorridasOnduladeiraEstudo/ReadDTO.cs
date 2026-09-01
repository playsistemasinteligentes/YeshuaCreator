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
    public partial record CorridasOnduladeiraEstudoDTO
    {
    public int id { get; set; }
    public string bol_id { get; set; }
    public string bol_id_origem { get; set; }
    public Decimal pro_largura_peca { get; set; }
    public Decimal pro_largura_peca_programado { get; set; }
    public Decimal pro_comprimento_peca { get; set; }
    public Decimal pro_comprimento_peca_programado { get; set; }
    public Decimal pro_utilizou_refile_obrigatorio { get; set; }
    public string pro_vincos_recalculados { get; set; }
    public string cor_solver { get; set; }
    public Decimal cor_gramatura_papeis_programados { get; set; }
    public Decimal cor_custo_papeis_programados { get; set; }
    public Decimal cor_gramatura_resina_programados { get; set; }
    public Decimal cor_custo_resina_programados { get; set; }
    public Decimal cor_tolerancia_menos { get; set; }
    public Decimal cor_tolerancia_mais { get; set; }
    public int cor_pilhas_por_palete { get; set; }
    public Decimal cor_m_linear_realizado { get; set; }
    public string pro_id_palete { get; set; }
    public string cor_status_palete { get; set; }
    public Decimal cor_grupo_produtivo { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration