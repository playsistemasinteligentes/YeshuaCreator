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
                    public partial class CTeSaidaMDFeEntity : ICTeSaidaMDFeEntity
{
    public int? Id { get; set; }
    public int CTeTentativaEmissaoId { get; set; }
    public string CorrelationId { get; set; }
    public string ChaveAcessoCTe { get; set; }
    public string SnapshotHash { get; set; }
    public string OutboxMessageId { get; set; }
    public DateTime? PublicadoEmUtc { get; set; }
    public string UltimoErro { get; set; }
    public int Status { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CTeSaidaMDFeEntity(int? id, int ctetentativaemissaoid, string correlationid, string chaveacessocte, string snapshothash, string outboxmessageid, DateTime? publicadoemutc, string ultimoerro, int status ){
 Id = id; 
 CTeTentativaEmissaoId = ctetentativaemissaoid; 
 CorrelationId = correlationid; 
 ChaveAcessoCTe = chaveacessocte; 
 SnapshotHash = snapshothash; 
 OutboxMessageId = outboxmessageid; 
 PublicadoEmUtc = (publicadoemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : publicadoemutc; 
 UltimoErro = ultimoerro; 
 Status = status; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
   if(string.IsNullOrEmpty(ChaveAcessoCTe))
   this._erroMensagem.Add("Chave CT-e deve ser informado.");
   if(string.IsNullOrEmpty(SnapshotHash))
   this._erroMensagem.Add("Hash Snapshot deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration