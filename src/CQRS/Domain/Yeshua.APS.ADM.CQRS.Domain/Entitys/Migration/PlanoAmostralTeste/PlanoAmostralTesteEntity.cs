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
                    public partial class PlanoAmostralTesteEntity : IPlanoAmostralTesteEntity
{
    public Decimal? GRP_TIPO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public int PAT_ID { get; set; }
    public int? PAT_QTD_CAIXAS_DE { get; set; }
    public int? PAT_QTD_CAIXAS_ATE { get; set; }
    public int? PAT_N_AMOSTRAGEM { get; set; }
    public Decimal? PAT_PERCENT_ESPECIF { get; set; }
    private List<string> _erroMensagem = null;
 internal PlanoAmostralTesteEntity(Decimal? grp_tipo, int pat_id, int? pat_qtd_caixas_de, int? pat_qtd_caixas_ate, int? pat_n_amostragem, Decimal? pat_percent_especif ){
 GRP_TIPO = grp_tipo; 
 PAT_ID = pat_id; 
 PAT_QTD_CAIXAS_DE = pat_qtd_caixas_de; 
 PAT_QTD_CAIXAS_ATE = pat_qtd_caixas_ate; 
 PAT_N_AMOSTRAGEM = pat_n_amostragem; 
 PAT_PERCENT_ESPECIF = pat_percent_especif; 
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