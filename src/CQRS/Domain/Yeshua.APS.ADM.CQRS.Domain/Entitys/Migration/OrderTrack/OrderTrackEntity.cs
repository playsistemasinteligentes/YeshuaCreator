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
                    public partial class OrderTrackEntity : IOrderTrackEntity
{
    public int? Id { get; set; }
    public int OTK_ID { get; set; }
    public Decimal OTK_SEQUENCIA { get; set; }
    public int OTK_VERSSAO { get; set; }
    public string ORD_ID { get; set; }
    public string OTK_EVENTO { get; set; }
    public DateTime? OTK_DATA_NECESSIDADE_DE { get; set; }
    public DateTime? OTK_DATA_NECESSIDADE_ATE { get; set; }
    public DateTime? OTK_DATA_PREVISTA { get; set; }
    public DateTime? OTK_DATA_REALIZADA { get; set; }
    public int? FPR_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal OrderTrackEntity(int? id, int otk_id, Decimal otk_sequencia, int otk_verssao, string ord_id, string otk_evento, DateTime? otk_data_necessidade_de, DateTime? otk_data_necessidade_ate, DateTime? otk_data_prevista, DateTime? otk_data_realizada, int? fpr_id ){
 Id = id; 
 OTK_ID = otk_id; 
 OTK_SEQUENCIA = otk_sequencia; 
 OTK_VERSSAO = otk_verssao; 
 ORD_ID = ord_id; 
 OTK_EVENTO = otk_evento; 
 OTK_DATA_NECESSIDADE_DE = (otk_data_necessidade_de < (new DateTime(1800, 1, 1))) ? DateTime.Now : otk_data_necessidade_de; 
 OTK_DATA_NECESSIDADE_ATE = (otk_data_necessidade_ate < (new DateTime(1800, 1, 1))) ? DateTime.Now : otk_data_necessidade_ate; 
 OTK_DATA_PREVISTA = (otk_data_prevista < (new DateTime(1800, 1, 1))) ? DateTime.Now : otk_data_prevista; 
 OTK_DATA_REALIZADA = (otk_data_realizada < (new DateTime(1800, 1, 1))) ? DateTime.Now : otk_data_realizada; 
 FPR_ID = fpr_id; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(ORD_ID))
   this._erroMensagem.Add("ORD ID deve ser informado.");
   if(string.IsNullOrEmpty(OTK_EVENTO))
   this._erroMensagem.Add("OTK EVENTO deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration