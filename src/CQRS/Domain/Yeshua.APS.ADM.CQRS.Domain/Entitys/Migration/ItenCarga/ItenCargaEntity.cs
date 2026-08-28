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
                    public partial class ItenCargaEntity : IItenCargaEntity
{
    public int? Id { get; set; }
    public string CAR_ID { get; set; }
    public string ORD_ID { get; set; }
    public DateTime ITC_ENTREGA_PLANEJADA { get; set; }
    public DateTime ITC_ENTREGA_REALIZADA { get; set; }
    public int ITC_ORDEM_ENTREGA { get; set; }
    public Decimal ITC_QTD_PLANEJADA { get; set; }
    public Decimal ITC_QTD_REALIZADA { get; set; }
    public string ORD_HASH_KEY { get; set; }
    public string NOT_ID { get; set; }
    public DateTime? NOT_EMISSAO { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal ItenCargaEntity(int? id, string car_id, string ord_id, DateTime itc_entrega_planejada, DateTime itc_entrega_realizada, int itc_ordem_entrega, Decimal itc_qtd_planejada, Decimal itc_qtd_realizada, string ord_hash_key, string not_id, DateTime? not_emissao ){
 Id = id; 
 CAR_ID = car_id; 
 ORD_ID = ord_id; 
 ITC_ENTREGA_PLANEJADA = (itc_entrega_planejada < (new DateTime(1800, 1, 1))) ? DateTime.Now : itc_entrega_planejada; 
 ITC_ENTREGA_REALIZADA = (itc_entrega_realizada < (new DateTime(1800, 1, 1))) ? DateTime.Now : itc_entrega_realizada; 
 ITC_ORDEM_ENTREGA = itc_ordem_entrega; 
 ITC_QTD_PLANEJADA = itc_qtd_planejada; 
 ITC_QTD_REALIZADA = itc_qtd_realizada; 
 ORD_HASH_KEY = ord_hash_key; 
 NOT_ID = not_id; 
 NOT_EMISSAO = (not_emissao < (new DateTime(1800, 1, 1))) ? DateTime.Now : not_emissao; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CAR_ID))
   this._erroMensagem.Add("CAR ID deve ser informado.");
   if(string.IsNullOrEmpty(ORD_ID))
   this._erroMensagem.Add("ORD ID deve ser informado.");
   if (ITC_ENTREGA_PLANEJADA == null || ITC_ENTREGA_PLANEJADA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("ITC ENTREGA PLANEJADA deve ser informado.");
   if (ITC_ENTREGA_REALIZADA == null || ITC_ENTREGA_REALIZADA < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("ITC ENTREGA REALIZADA deve ser informado.");
   if (ITC_ORDEM_ENTREGA == null)
   this._erroMensagem.Add("ITC ORDEM ENTREGA deve ser informado.");
   if (ITC_QTD_PLANEJADA == null)
   this._erroMensagem.Add("ITC QTD PLANEJADA deve ser informado.");
   if (ITC_QTD_REALIZADA == null)
   this._erroMensagem.Add("ITC QTD REALIZADA deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration