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
                    public partial class RoteiroEntity : IRoteiroEntity
{
    public string MAQ_ID { get; set; }
    public string PRO_ID { get; set; }
    public int ROT_SEQ_TRANFORMACAO { get; set; }
    public string GMA_ID { get; set; }
    public Decimal? ROT_PECAS_POR_PULSO { get; set; }
    public Decimal? ROT_PRIORIDADE_INFORMADA { get; set; }
    public string ROT_ACAO { get; set; }
    public Decimal ROT_PERFORMANCE { get; set; }
    public Decimal? ROT_TEMPO_SETUP { get; set; }
    public Decimal? ROT_TEMPO_SETUP_AJUSTE { get; set; }
    public int? ROT_VA_PARA_SEQ_TRANSFORMACAO { get; set; }
    public string ROT_STATUS { get; set; }
    public Decimal? ROT_HIERARQUIA_SEQ_TRANSFORMACAO { get; set; }
    public int? ROT_AVALIA_CUSTO { get; set; }
    public string ROT_OPERACOES { get; set; }
    public string ROT_EXCECAO_OPERACOES { get; set; }
    public Decimal? ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR { get; set; }
    public string ROT_LINHA_DIRETA { get; set; }
    public int? TEM_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal RoteiroEntity(string maq_id, string pro_id, int rot_seq_tranformacao, string gma_id, Decimal? rot_pecas_por_pulso, Decimal? rot_prioridade_informada, string rot_acao, Decimal rot_performance, Decimal? rot_tempo_setup, Decimal? rot_tempo_setup_ajuste, int? rot_va_para_seq_transformacao, string rot_status, Decimal? rot_hierarquia_seq_transformacao, int? rot_avalia_custo, string rot_operacoes, string rot_excecao_operacoes, Decimal? rot_percentual_inicio_passo_anterior, string rot_linha_direta, int? tem_id ){
 MAQ_ID = maq_id; 
 PRO_ID = pro_id; 
 ROT_SEQ_TRANFORMACAO = rot_seq_tranformacao; 
 GMA_ID = gma_id; 
 ROT_PECAS_POR_PULSO = rot_pecas_por_pulso; 
 ROT_PRIORIDADE_INFORMADA = rot_prioridade_informada; 
 ROT_ACAO = rot_acao; 
 ROT_PERFORMANCE = rot_performance; 
 ROT_TEMPO_SETUP = rot_tempo_setup; 
 ROT_TEMPO_SETUP_AJUSTE = rot_tempo_setup_ajuste; 
 ROT_VA_PARA_SEQ_TRANSFORMACAO = rot_va_para_seq_transformacao; 
 ROT_STATUS = rot_status; 
 ROT_HIERARQUIA_SEQ_TRANSFORMACAO = rot_hierarquia_seq_transformacao; 
 ROT_AVALIA_CUSTO = rot_avalia_custo; 
 ROT_OPERACOES = rot_operacoes; 
 ROT_EXCECAO_OPERACOES = rot_excecao_operacoes; 
 ROT_PERCENTUAL_INICIO_PASSO_ANTERIOR = rot_percentual_inicio_passo_anterior; 
 ROT_LINHA_DIRETA = rot_linha_direta; 
 TEM_ID = tem_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(MAQ_ID))
   this._erroMensagem.Add("Codigo da Maquina deve ser informado.");
   if(string.IsNullOrEmpty(PRO_ID))
   this._erroMensagem.Add("Codigo do Produto deve ser informado.");
   if (ROT_SEQ_TRANFORMACAO == null)
   this._erroMensagem.Add("Sequencia de Transformacao deve ser informado.");
   if (ROT_PERFORMANCE == null)
   this._erroMensagem.Add("Performance Pulsos por Segundo deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration