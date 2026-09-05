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
                    public partial class TransportadoraEntity : ITransportadoraEntity
{
    public int? Id { get; set; }
    public string TRA_ID { get; set; }
    public string TRA_NOME { get; set; }
    public string TRA_EMAIL { get; set; }
    public string TRA_RESPONSAVEL { get; set; }
    public string TRA_FONE { get; set; }
    public string TRA_ID_INTEGRACAO { get; set; }
    public string TRA_ID_INTEGRACAO_ERP { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal TransportadoraEntity(int? id, string tra_id, string tra_nome, string tra_email, string tra_responsavel, string tra_fone, string tra_id_integracao, string tra_id_integracao_erp ){
 Id = id; 
 TRA_ID = tra_id; 
 TRA_NOME = tra_nome; 
 TRA_EMAIL = tra_email; 
 TRA_RESPONSAVEL = tra_responsavel; 
 TRA_FONE = tra_fone; 
 TRA_ID_INTEGRACAO = tra_id_integracao; 
 TRA_ID_INTEGRACAO_ERP = tra_id_integracao_erp; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(TRA_ID))
   this._erroMensagem.Add("TRA ID deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration