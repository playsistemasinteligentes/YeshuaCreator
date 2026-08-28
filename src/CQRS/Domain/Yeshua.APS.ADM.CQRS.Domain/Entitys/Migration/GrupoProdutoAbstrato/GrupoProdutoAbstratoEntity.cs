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
                    public partial class GrupoProdutoAbstratoEntity : IGrupoProdutoAbstratoEntity
{
    public string GRP_ID { get; set; }
    public string GRP_DESCRICAO { get; set; }
    public int? TEM_ID { get; set; }
    public Decimal? GRP_TIPO { get; set; }
    public string GRP_PAP_ONDA { get; set; }
    public Decimal? GRP_PAP_GRAMATURA { get; set; }
    public Decimal? GRP_PAP_ALTURA { get; set; }
    public string GRP_PAP_NOME_COMERCIAL { get; set; }
    public string GRP_ATIVO { get; set; }
    public DateTime? GRP_DT_CRIACAO { get; set; }
    public string GRP_PAPEL1 { get; set; }
    public string GRP_PAPEL2 { get; set; }
    public string GRP_PAPEL3 { get; set; }
    public string GRP_PAPEL4 { get; set; }
    public string GRP_PAPEL5 { get; set; }
    public string GRP_ID_INTEGRACAO { get; set; }
    public string GRP_ID_INTEGRACAO_ERP { get; set; }
    public int? GRP_TYPE { get; set; }
    public Decimal? GRP_PERFORMANCE { get; set; }
    public Decimal? GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO { get; set; }
    public string GRP_RESINA { get; set; }
    public string GRP_ENDURECEDOR_MIOLO { get; set; }
    public int VIN_ID { get; set; }
    public Decimal? GRP_COLUNA_DE { get; set; }
    public Decimal? GRP_COLUNA_ATE { get; set; }
    public Decimal? GRP_CRUSH { get; set; }
    public string GRP_ID_FAMILIA { get; set; }
    public Decimal? GRP_REFILE_LARGURA { get; set; }
    public Decimal? GRP_REFILE_COMPRIMENTO { get; set; }
    public string GRP_TIPO_LAP { get; set; }
    public string GRP_LAP_PROLONGADO { get; set; }
    public Decimal? GRP_TAMANHO_LAP_OND_SIMPLES { get; set; }
    public Decimal? GRP_TAMANHO_LAP_OND_DUPLA { get; set; }
    public Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES { get; set; }
    public Decimal? GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA { get; set; }
    public string GRP_FEFCO { get; set; }
    public int? GRP_TOLERANCIA_DIMENCAO_CHAPA_DE { get; set; }
    public int? GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE { get; set; }
    public string GRP_PREFIXO_ID_PRODUTO { get; set; }
    public Decimal? GRP_COLUNA_CAIXA { get; set; }
    public Decimal? GRP_COLUNA_CHAPA { get; set; }
    public Decimal? GRP_MULLEN { get; set; }
    public int? GRP_TENDENCIA_TOLERANCIA_PEDIDO { get; set; }
    public Decimal? GRP_PERCENTUAL_PERDA_MEDIA { get; set; }
    public int? GRP_FILTRA_SEQ_TRANS { get; set; }
    public string GRP_IMG_CAIXA { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal GrupoProdutoAbstratoEntity(string grp_id, string grp_descricao, int? tem_id, Decimal? grp_tipo, string grp_pap_onda, Decimal? grp_pap_gramatura, Decimal? grp_pap_altura, string grp_pap_nome_comercial, string grp_ativo, DateTime? grp_dt_criacao, string grp_papel1, string grp_papel2, string grp_papel3, string grp_papel4, string grp_papel5, string grp_id_integracao, string grp_id_integracao_erp, int? grp_type, Decimal? grp_performance, Decimal? grp_performance_metro_linear_por_segundo, string grp_resina, string grp_endurecedor_miolo, int vin_id, Decimal? grp_coluna_de, Decimal? grp_coluna_ate, Decimal? grp_crush, string grp_id_familia, Decimal? grp_refile_largura, Decimal? grp_refile_comprimento, string grp_tipo_lap, string grp_lap_prolongado, Decimal? grp_tamanho_lap_ond_simples, Decimal? grp_tamanho_lap_ond_dupla, Decimal? grp_tamanho_lap_prolongado_ond_simples, Decimal? grp_tamanho_lap_prolongado_ond_dupla, string grp_fefco, int? grp_tolerancia_dimencao_chapa_de, int? grp_tolerancia_dimencao_chapa_ate, string grp_prefixo_id_produto, Decimal? grp_coluna_caixa, Decimal? grp_coluna_chapa, Decimal? grp_mullen, int? grp_tendencia_tolerancia_pedido, Decimal? grp_percentual_perda_media, int? grp_filtra_seq_trans, string grp_img_caixa ){
 GRP_ID = grp_id; 
 GRP_DESCRICAO = grp_descricao; 
 TEM_ID = tem_id; 
 GRP_TIPO = grp_tipo; 
 GRP_PAP_ONDA = grp_pap_onda; 
 GRP_PAP_GRAMATURA = grp_pap_gramatura; 
 GRP_PAP_ALTURA = grp_pap_altura; 
 GRP_PAP_NOME_COMERCIAL = grp_pap_nome_comercial; 
 GRP_ATIVO = grp_ativo; 
 GRP_DT_CRIACAO = (grp_dt_criacao < (new DateTime(1800, 1, 1))) ? DateTime.Now : grp_dt_criacao; 
 GRP_PAPEL1 = grp_papel1; 
 GRP_PAPEL2 = grp_papel2; 
 GRP_PAPEL3 = grp_papel3; 
 GRP_PAPEL4 = grp_papel4; 
 GRP_PAPEL5 = grp_papel5; 
 GRP_ID_INTEGRACAO = grp_id_integracao; 
 GRP_ID_INTEGRACAO_ERP = grp_id_integracao_erp; 
 GRP_TYPE = grp_type; 
 GRP_PERFORMANCE = grp_performance; 
 GRP_PERFORMANCE_METRO_LINEAR_POR_SEGUNDO = grp_performance_metro_linear_por_segundo; 
 GRP_RESINA = grp_resina; 
 GRP_ENDURECEDOR_MIOLO = grp_endurecedor_miolo; 
 VIN_ID = vin_id; 
 GRP_COLUNA_DE = grp_coluna_de; 
 GRP_COLUNA_ATE = grp_coluna_ate; 
 GRP_CRUSH = grp_crush; 
 GRP_ID_FAMILIA = grp_id_familia; 
 GRP_REFILE_LARGURA = grp_refile_largura; 
 GRP_REFILE_COMPRIMENTO = grp_refile_comprimento; 
 GRP_TIPO_LAP = grp_tipo_lap; 
 GRP_LAP_PROLONGADO = grp_lap_prolongado; 
 GRP_TAMANHO_LAP_OND_SIMPLES = grp_tamanho_lap_ond_simples; 
 GRP_TAMANHO_LAP_OND_DUPLA = grp_tamanho_lap_ond_dupla; 
 GRP_TAMANHO_LAP_PROLONGADO_OND_SIMPLES = grp_tamanho_lap_prolongado_ond_simples; 
 GRP_TAMANHO_LAP_PROLONGADO_OND_DUPLA = grp_tamanho_lap_prolongado_ond_dupla; 
 GRP_FEFCO = grp_fefco; 
 GRP_TOLERANCIA_DIMENCAO_CHAPA_DE = grp_tolerancia_dimencao_chapa_de; 
 GRP_TOLERANCIA_DIMENCAO_CHAPA_ATE = grp_tolerancia_dimencao_chapa_ate; 
 GRP_PREFIXO_ID_PRODUTO = grp_prefixo_id_produto; 
 GRP_COLUNA_CAIXA = grp_coluna_caixa; 
 GRP_COLUNA_CHAPA = grp_coluna_chapa; 
 GRP_MULLEN = grp_mullen; 
 GRP_TENDENCIA_TOLERANCIA_PEDIDO = grp_tendencia_tolerancia_pedido; 
 GRP_PERCENTUAL_PERDA_MEDIA = grp_percentual_perda_media; 
 GRP_FILTRA_SEQ_TRANS = grp_filtra_seq_trans; 
 GRP_IMG_CAIXA = grp_img_caixa; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(GRP_ID))
   this._erroMensagem.Add("GRP ID deve ser informado.");
   if(string.IsNullOrEmpty(GRP_DESCRICAO))
   this._erroMensagem.Add("GRP DESCRICAO deve ser informado.");
   if (VIN_ID == null)
   this._erroMensagem.Add("VIN ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration