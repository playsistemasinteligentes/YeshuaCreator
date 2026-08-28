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
                    public partial class MovimentosEntity : IMovimentosEntity
{
    public int MOV_ID { get; set; }
    public string MOV_DATA { get; set; }
    public Decimal MOV_VALOR { get; set; }
    public int MOV_PLAID { get; set; }
    public int MOV_UNID { get; set; }
    public int? Tr_Unidade_UNI_ID { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal MovimentosEntity(int mov_id, string mov_data, Decimal mov_valor, int mov_plaid, int mov_unid, int? tr_unidade_uni_id ){
 MOV_ID = mov_id; 
 MOV_DATA = mov_data; 
 MOV_VALOR = mov_valor; 
 MOV_PLAID = mov_plaid; 
 MOV_UNID = mov_unid; 
 Tr_Unidade_UNI_ID = tr_unidade_uni_id; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if (MOV_ID == null)
   this._erroMensagem.Add("MOV ID deve ser informado.");
   if(string.IsNullOrEmpty(MOV_DATA))
   this._erroMensagem.Add("MOV DATA deve ser informado.");
   if (MOV_VALOR == null)
   this._erroMensagem.Add("MOV VALOR deve ser informado.");
   if (MOV_PLAID == null)
   this._erroMensagem.Add("MOV PLAID deve ser informado.");
   if (MOV_UNID == null)
   this._erroMensagem.Add("MOV UNID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration