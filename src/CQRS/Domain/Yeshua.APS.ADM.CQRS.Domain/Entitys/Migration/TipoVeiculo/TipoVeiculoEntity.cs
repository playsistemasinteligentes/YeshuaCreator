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
                    public partial class TipoVeiculoEntity : ITipoVeiculoEntity
{
    public int? Id { get; set; }
    public int TIP_ID { get; set; }
    public string TIP_DESCRICAO { get; set; }
    public int? TIP_QTD_DISPONIVEL { get; set; }
    public Decimal? TIP_VALOR_KM { get; set; }
    public Decimal? TIP_VALOR_DIARIA { get; set; }
    public Decimal? TIP_VALOR_AJUDANTE { get; set; }
    public Decimal? TIP_QTD_EIXOS { get; set; }
    public Decimal? TIP_VELOCIDADE_MEDIA { get; set; }
    public Decimal? TIP_CAPACIDADE_ALTURA { get; set; }
    public Decimal? TIP_CAPACIDADE_COMPRIMENTO { get; set; }
    public Decimal? TIP_CAPACIDADE_LARGURA { get; set; }
    public Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_E { get; set; }
    public Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E { get; set; }
    public Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_E { get; set; }
    public Decimal? TIP_CAPACIDADE_ALTURA_PESCOCO_D { get; set; }
    public Decimal? TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D { get; set; }
    public Decimal? TIP_CAPACIDADE_LARGURA_PESCOCO_D { get; set; }
    public Decimal? TIP_CAPACIDADE_M3 { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TipoVeiculoEntity(int? id, int tip_id, string tip_descricao, int? tip_qtd_disponivel, Decimal? tip_valor_km, Decimal? tip_valor_diaria, Decimal? tip_valor_ajudante, Decimal? tip_qtd_eixos, Decimal? tip_velocidade_media, Decimal? tip_capacidade_altura, Decimal? tip_capacidade_comprimento, Decimal? tip_capacidade_largura, Decimal? tip_capacidade_altura_pescoco_e, Decimal? tip_capacidade_comprimento_pescoco_e, Decimal? tip_capacidade_largura_pescoco_e, Decimal? tip_capacidade_altura_pescoco_d, Decimal? tip_capacidade_comprimento_pescoco_d, Decimal? tip_capacidade_largura_pescoco_d, Decimal? tip_capacidade_m3 ){
 Id = id; 
 TIP_ID = tip_id; 
 TIP_DESCRICAO = tip_descricao; 
 TIP_QTD_DISPONIVEL = tip_qtd_disponivel; 
 TIP_VALOR_KM = tip_valor_km; 
 TIP_VALOR_DIARIA = tip_valor_diaria; 
 TIP_VALOR_AJUDANTE = tip_valor_ajudante; 
 TIP_QTD_EIXOS = tip_qtd_eixos; 
 TIP_VELOCIDADE_MEDIA = tip_velocidade_media; 
 TIP_CAPACIDADE_ALTURA = tip_capacidade_altura; 
 TIP_CAPACIDADE_COMPRIMENTO = tip_capacidade_comprimento; 
 TIP_CAPACIDADE_LARGURA = tip_capacidade_largura; 
 TIP_CAPACIDADE_ALTURA_PESCOCO_E = tip_capacidade_altura_pescoco_e; 
 TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_E = tip_capacidade_comprimento_pescoco_e; 
 TIP_CAPACIDADE_LARGURA_PESCOCO_E = tip_capacidade_largura_pescoco_e; 
 TIP_CAPACIDADE_ALTURA_PESCOCO_D = tip_capacidade_altura_pescoco_d; 
 TIP_CAPACIDADE_COMPRIMENTO_PESCOCO_D = tip_capacidade_comprimento_pescoco_d; 
 TIP_CAPACIDADE_LARGURA_PESCOCO_D = tip_capacidade_largura_pescoco_d; 
 TIP_CAPACIDADE_M3 = tip_capacidade_m3; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (TIP_ID == null)
   this._erroMensagem.Add("TIP ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration