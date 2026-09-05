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
                    public partial class ItensOrcamentoEntity : IItensOrcamentoEntity
{
    public int? Id { get; set; }
    public int ITO_ID { get; set; }
    public int? ORC_ID { get; set; }
    public int? TIP_ID { get; set; }
    public string PRO_ID { get; set; }
    public string ITO_OBS { get; set; }
    public Decimal? ITO_QUANTIDADE { get; set; }
    public Decimal? ITO_CUSTO { get; set; }
    public Decimal? ITO_MARGEM { get; set; }
    public Decimal? ITO_VALOR_UNITARIO { get; set; }
    public DateTime? ITO_VERSSAO_CUSTO { get; set; }
    public string ITO_STATUS { get; set; }
    public Decimal? ITO_ERP_CUSTOS_FIXOS { get; set; }
    public Decimal? ITO_ERP_CUSTOS_VARIAVEIS { get; set; }
    public Decimal? ITO_ERP_DESPESAS_VAR_VENDA { get; set; }
    public Decimal? ITO_ERP_IMPOSTOS { get; set; }
    public string GRP_ID_COMPOSICAO { get; set; }
    public Decimal? ITO_LARGURA { get; set; }
    public Decimal? ITO_COMPRIMENTO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ItensOrcamentoEntity(int? id, int ito_id, int? orc_id, int? tip_id, string pro_id, string ito_obs, Decimal? ito_quantidade, Decimal? ito_custo, Decimal? ito_margem, Decimal? ito_valor_unitario, DateTime? ito_verssao_custo, string ito_status, Decimal? ito_erp_custos_fixos, Decimal? ito_erp_custos_variaveis, Decimal? ito_erp_despesas_var_venda, Decimal? ito_erp_impostos, string grp_id_composicao, Decimal? ito_largura, Decimal? ito_comprimento ){
 Id = id; 
 ITO_ID = ito_id; 
 ORC_ID = orc_id; 
 TIP_ID = tip_id; 
 PRO_ID = pro_id; 
 ITO_OBS = ito_obs; 
 ITO_QUANTIDADE = ito_quantidade; 
 ITO_CUSTO = ito_custo; 
 ITO_MARGEM = ito_margem; 
 ITO_VALOR_UNITARIO = ito_valor_unitario; 
 ITO_VERSSAO_CUSTO = (ito_verssao_custo < (new DateTime(1800, 1, 1))) ? DateTime.Now : ito_verssao_custo; 
 ITO_STATUS = ito_status; 
 ITO_ERP_CUSTOS_FIXOS = ito_erp_custos_fixos; 
 ITO_ERP_CUSTOS_VARIAVEIS = ito_erp_custos_variaveis; 
 ITO_ERP_DESPESAS_VAR_VENDA = ito_erp_despesas_var_venda; 
 ITO_ERP_IMPOSTOS = ito_erp_impostos; 
 GRP_ID_COMPOSICAO = grp_id_composicao; 
 ITO_LARGURA = ito_largura; 
 ITO_COMPRIMENTO = ito_comprimento; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration