// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class CorridasOnduladeiraEntity : ICorridasOnduladeiraEntity
{
    public string BOL_ID { get; set; }
    public string BOL_ID_ORIGEM { get; set; }
    public Decimal? PRO_LARGURA_PECA { get; set; }
    public Decimal? PRO_LARGURA_PECA_PROGRAMADO { get; set; }
    public Decimal? PRO_COMPRIMENTO_PECA { get; set; }
    public Decimal? PRO_COMPRIMENTO_PECA_PROGRAMADO { get; set; }
    public Decimal? PRO_UTILIZOU_REFILE_OBRIGATORIO { get; set; }
    public string PRO_VINCOS_RECALCULADOS { get; set; }
    public string COR_SOLVER { get; set; }
    public Decimal? COR_GRAMATURA_PAPEIS_PROGRAMADOS { get; set; }
    public Decimal? COR_CUSTO_PAPEIS_PROGRAMADOS { get; set; }
    public Decimal? COR_GRAMATURA_RESINA_PROGRAMADOS { get; set; }
    public Decimal? COR_CUSTO_RESINA_PROGRAMADOS { get; set; }
    public Decimal? COR_TOLERANCIA_MENOS { get; set; }
    public Decimal? COR_TOLERANCIA_MAIS { get; set; }
    public int? COR_PILHAS_POR_PALETE { get; set; }
    public string COR_COR_FILA { get; set; }
    public Decimal? COR_M_LINEAR_REALIZADO { get; set; }
    public string PRO_ID_PALETE { get; set; }
    public string COR_STATUS_PALETE { get; set; }
    public Decimal? COR_GRUPO_PRODUTIVO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public int COR_ID { get; set; }
    public string COR_STATUS { get; set; }
    public string COR_STATUS_INTERFACE { get; set; }
    public string MAQ_ID { get; set; }
    public int? COR_ID_INTERFACE { get; set; }
    public int? COR_SEQUENCIA { get; set; }
    public int? COR_SEQUENCIA_ORIGEM { get; set; }
    public string ORD_ID { get; set; }
    public int? FPR_SEQ_REPETICAO { get; set; }
    public int? ROT_SEQ_TRANFORMACAO { get; set; }
    public int? COR_FACAO { get; set; }
    public int? COR_FORMATO_BOBINA { get; set; }
    public DateTime? COR_INICIO_PREVISTO { get; set; }
    public DateTime? COR_FIM_PREVISTO { get; set; }
    public string PRO_ID { get; set; }
    public int? COR_QTD_PLANEJADO { get; set; }
    public int? PRO_QTD_PACAS { get; set; }
    public int? COR_PECAS_LARGURA { get; set; }
    private List<string> _erroMensagem = null;
 internal CorridasOnduladeiraEntity(string bol_id, string bol_id_origem, Decimal? pro_largura_peca, Decimal? pro_largura_peca_programado, Decimal? pro_comprimento_peca, Decimal? pro_comprimento_peca_programado, Decimal? pro_utilizou_refile_obrigatorio, string pro_vincos_recalculados, string cor_solver, Decimal? cor_gramatura_papeis_programados, Decimal? cor_custo_papeis_programados, Decimal? cor_gramatura_resina_programados, Decimal? cor_custo_resina_programados, Decimal? cor_tolerancia_menos, Decimal? cor_tolerancia_mais, int? cor_pilhas_por_palete, string cor_cor_fila, Decimal? cor_m_linear_realizado, string pro_id_palete, string cor_status_palete, Decimal? cor_grupo_produtivo, int cor_id, string cor_status, string cor_status_interface, string maq_id, int? cor_id_interface, int? cor_sequencia, int? cor_sequencia_origem, string ord_id, int? fpr_seq_repeticao, int? rot_seq_tranformacao, int? cor_facao, int? cor_formato_bobina, DateTime? cor_inicio_previsto, DateTime? cor_fim_previsto, string pro_id, int? cor_qtd_planejado, int? pro_qtd_pacas, int? cor_pecas_largura ){
 BOL_ID = bol_id; 
 BOL_ID_ORIGEM = bol_id_origem; 
 PRO_LARGURA_PECA = pro_largura_peca; 
 PRO_LARGURA_PECA_PROGRAMADO = pro_largura_peca_programado; 
 PRO_COMPRIMENTO_PECA = pro_comprimento_peca; 
 PRO_COMPRIMENTO_PECA_PROGRAMADO = pro_comprimento_peca_programado; 
 PRO_UTILIZOU_REFILE_OBRIGATORIO = pro_utilizou_refile_obrigatorio; 
 PRO_VINCOS_RECALCULADOS = pro_vincos_recalculados; 
 COR_SOLVER = cor_solver; 
 COR_GRAMATURA_PAPEIS_PROGRAMADOS = cor_gramatura_papeis_programados; 
 COR_CUSTO_PAPEIS_PROGRAMADOS = cor_custo_papeis_programados; 
 COR_GRAMATURA_RESINA_PROGRAMADOS = cor_gramatura_resina_programados; 
 COR_CUSTO_RESINA_PROGRAMADOS = cor_custo_resina_programados; 
 COR_TOLERANCIA_MENOS = cor_tolerancia_menos; 
 COR_TOLERANCIA_MAIS = cor_tolerancia_mais; 
 COR_PILHAS_POR_PALETE = cor_pilhas_por_palete; 
 COR_COR_FILA = cor_cor_fila; 
 COR_M_LINEAR_REALIZADO = cor_m_linear_realizado; 
 PRO_ID_PALETE = pro_id_palete; 
 COR_STATUS_PALETE = cor_status_palete; 
 COR_GRUPO_PRODUTIVO = cor_grupo_produtivo; 
 COR_ID = cor_id; 
 COR_STATUS = cor_status; 
 COR_STATUS_INTERFACE = cor_status_interface; 
 MAQ_ID = maq_id; 
 COR_ID_INTERFACE = cor_id_interface; 
 COR_SEQUENCIA = cor_sequencia; 
 COR_SEQUENCIA_ORIGEM = cor_sequencia_origem; 
 ORD_ID = ord_id; 
 FPR_SEQ_REPETICAO = fpr_seq_repeticao; 
 ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao; 
 COR_FACAO = cor_facao; 
 COR_FORMATO_BOBINA = cor_formato_bobina; 
 COR_INICIO_PREVISTO = (cor_inicio_previsto < (new DateTime(1800, 1, 1))) ? DateTime.Now : cor_inicio_previsto; 
 COR_FIM_PREVISTO = (cor_fim_previsto < (new DateTime(1800, 1, 1))) ? DateTime.Now : cor_fim_previsto; 
 PRO_ID = pro_id; 
 COR_QTD_PLANEJADO = cor_qtd_planejado; 
 PRO_QTD_PACAS = pro_qtd_pacas; 
 COR_PECAS_LARGURA = cor_pecas_largura; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (COR_ID == null)
   this._erroMensagem.Add("COR ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration