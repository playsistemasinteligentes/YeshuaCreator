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
    public partial record MovimentoEstoqueDTO
    {
    public int id { get; set; }
    public string produtoid { get; set; } = string.Empty;
    public string orderid { get; set; } = string.Empty;
    public string tipo { get; set; } = string.Empty;
    public string turnoid { get; set; } = string.Empty;
    public string turmaid { get; set; } = string.Empty;
    public Decimal quantidade { get; set; }
    public Decimal mov_peso_unitario { get; set; }
    public DateTime datahoracriacao { get; set; }
    public DateTime datahoraemissao { get; set; }
    public string diaturma { get; set; } = string.Empty;
    public string lote { get; set; } = string.Empty;
    public string sublote { get; set; } = string.Empty;
    public string maquinaid { get; set; } = string.Empty;
    public int use_id { get; set; }
    public string observacao { get; set; } = string.Empty;
    public string ocorrenciaid { get; set; } = string.Empty;
    public string armazem { get; set; } = string.Empty;
    public string endereco { get; set; } = string.Empty;
    public string estorno { get; set; } = string.Empty;
    public int sequenciatransformacao { get; set; }
    public int sequenciarepeticao { get; set; }
    public string obsopparcial { get; set; } = string.Empty;
    public string ocoidopparcial { get; set; } = string.Empty;
    public string mov_id_integracao { get; set; } = string.Empty;
    public string mov_id_integracao_erp { get; set; } = string.Empty;
    public string car_id { get; set; } = string.Empty;
    public int mov_id_destino { get; set; }
    public string pro_id_destino { get; set; } = string.Empty;
    public string mov_lote_destino { get; set; } = string.Empty;
    public string mov_sub_lote_destino { get; set; } = string.Empty;
    public int mov_id_origem { get; set; }
    public string pro_id_origem { get; set; } = string.Empty;
    public string mov_lote_origem { get; set; } = string.Empty;
    public string mov_sub_lote_origem { get; set; } = string.Empty;
    public int mov_type { get; set; }
    public string mov_doc { get; set; } = string.Empty;
    public string mov_aproveitamento { get; set; } = string.Empty;
    public string mov_retido { get; set; } = string.Empty;
    public string mov_vincos_onduladeira { get; set; } = string.Empty;
    public string bol_id { get; set; } = string.Empty;
    public string ord_id_origem { get; set; } = string.Empty;
    public int cor_sequencia { get; set; }
    public int ver_id { get; set; }
    public string mov_tipo_custo { get; set; } = string.Empty;
    public string mov_grupo_contabil { get; set; } = string.Empty;
    public string for_id { get; set; } = string.Empty;
    public string cli_id { get; set; } = string.Empty;
    public string operationalentityid { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration