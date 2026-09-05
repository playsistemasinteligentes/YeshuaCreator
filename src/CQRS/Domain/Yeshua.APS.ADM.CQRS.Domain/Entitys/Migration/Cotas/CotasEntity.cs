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
                    public partial class CotasEntity : ICotasEntity
{
    public int? Id { get; set; }
    public int COT_ID { get; set; }
    public DateTime? COT_DATA_DE { get; set; }
    public DateTime? COT_DATA_ATE { get; set; }
    public Decimal? COT_VALOR { get; set; }
    public Decimal? COT_OCUPADO { get; set; }
    public int REP_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CotasEntity(int? id, int cot_id, DateTime? cot_data_de, DateTime? cot_data_ate, Decimal? cot_valor, Decimal? cot_ocupado, int rep_id ){
 Id = id; 
 COT_ID = cot_id; 
 COT_DATA_DE = (cot_data_de < (new DateTime(1800, 1, 1))) ? DateTime.Now : cot_data_de; 
 COT_DATA_ATE = (cot_data_ate < (new DateTime(1800, 1, 1))) ? DateTime.Now : cot_data_ate; 
 COT_VALOR = cot_valor; 
 COT_OCUPADO = cot_ocupado; 
 REP_ID = rep_id; 
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