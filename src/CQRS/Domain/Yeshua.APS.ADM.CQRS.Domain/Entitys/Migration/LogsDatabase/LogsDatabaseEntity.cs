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
                    public partial class LogsDatabaseEntity : ILogsDatabaseEntity
{
    public int LOGS_ID { get; set; }
    public string LOGS_TABLE { get; set; }
    public string LOGS_KEY { get; set; }
    public string LOGS_KEY1 { get; set; }
    public string LOGS_KEY2 { get; set; }
    public string LOGS_KEY3 { get; set; }
    public string LOGS_KEY4 { get; set; }
    public string LOGS_COLUMN { get; set; }
    public string LOGS_BEFORE { get; set; }
    public string LOGS_AFTER { get; set; }
    public string LOGS_ACTION { get; set; }
    public DateTime LOGS_DATE { get; set; }
    public int USE_ID { get; set; }
    public string LOGS_ORIGEM { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal LogsDatabaseEntity(int logs_id, string logs_table, string logs_key, string logs_key1, string logs_key2, string logs_key3, string logs_key4, string logs_column, string logs_before, string logs_after, string logs_action, DateTime logs_date, int use_id, string logs_origem ){
 LOGS_ID = logs_id; 
 LOGS_TABLE = logs_table; 
 LOGS_KEY = logs_key; 
 LOGS_KEY1 = logs_key1; 
 LOGS_KEY2 = logs_key2; 
 LOGS_KEY3 = logs_key3; 
 LOGS_KEY4 = logs_key4; 
 LOGS_COLUMN = logs_column; 
 LOGS_BEFORE = logs_before; 
 LOGS_AFTER = logs_after; 
 LOGS_ACTION = logs_action; 
 LOGS_DATE = (logs_date < (new DateTime(1800, 1, 1))) ? DateTime.Now : logs_date; 
 USE_ID = use_id; 
 LOGS_ORIGEM = logs_origem; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (LOGS_ID == null)
   this._erroMensagem.Add("LOGS ID deve ser informado.");
   if(string.IsNullOrEmpty(LOGS_TABLE))
   this._erroMensagem.Add("LOGS TABLE deve ser informado.");
   if(string.IsNullOrEmpty(LOGS_KEY))
   this._erroMensagem.Add("LOGS KEY deve ser informado.");
   if(string.IsNullOrEmpty(LOGS_KEY1))
   this._erroMensagem.Add("LOGS KEY1 deve ser informado.");
   if(string.IsNullOrEmpty(LOGS_ACTION))
   this._erroMensagem.Add("LOGS ACTION deve ser informado.");
   if (LOGS_DATE == null || LOGS_DATE < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("LOGS DATE deve ser informado.");
   if (USE_ID == null)
   this._erroMensagem.Add("USE ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration