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
    public partial record GrupoProdutoAbstratoDTO
    {
    public string grp_id { get; set; }
    public string grp_descricao { get; set; }
    public int tem_id { get; set; }
    public Decimal grp_tipo { get; set; }
    public string grp_pap_onda { get; set; }
    public Decimal grp_pap_gramatura { get; set; }
    public Decimal grp_pap_altura { get; set; }
    public string grp_pap_nome_comercial { get; set; }
    public string grp_ativo { get; set; }
    public DateTime grp_dt_criacao { get; set; }
    public string grp_papel1 { get; set; }
    public string grp_papel2 { get; set; }
    public string grp_papel3 { get; set; }
    public string grp_papel4 { get; set; }
    public string grp_papel5 { get; set; }
    public string grp_id_integracao { get; set; }
    public string grp_id_integracao_erp { get; set; }
    public int grp_type { get; set; }
    public Decimal grp_performance { get; set; }
    public Decimal grp_performance_metro_linear_por_segundo { get; set; }
    public string grp_resina { get; set; }
    public string grp_endurecedor_miolo { get; set; }
    public int vin_id { get; set; }
    public Decimal grp_coluna_de { get; set; }
    public Decimal grp_coluna_ate { get; set; }
    public Decimal grp_crush { get; set; }
    public string grp_id_familia { get; set; }
    public Decimal grp_refile_largura { get; set; }
    public Decimal grp_refile_comprimento { get; set; }
    public string grp_tipo_lap { get; set; }
    public string grp_lap_prolongado { get; set; }
    public Decimal grp_tamanho_lap_ond_simples { get; set; }
    public Decimal grp_tamanho_lap_ond_dupla { get; set; }
    public Decimal grp_tamanho_lap_prolongado_ond_simples { get; set; }
    public Decimal grp_tamanho_lap_prolongado_ond_dupla { get; set; }
    public string grp_fefco { get; set; }
    public int grp_tolerancia_dimencao_chapa_de { get; set; }
    public int grp_tolerancia_dimencao_chapa_ate { get; set; }
    public string grp_prefixo_id_produto { get; set; }
    public Decimal grp_coluna_caixa { get; set; }
    public Decimal grp_coluna_chapa { get; set; }
    public Decimal grp_mullen { get; set; }
    public int grp_tendencia_tolerancia_pedido { get; set; }
    public Decimal grp_percentual_perda_media { get; set; }
    public int grp_filtra_seq_trans { get; set; }
    public string grp_img_caixa { get; set; }
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration