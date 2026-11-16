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
                    public partial class PlanoRecorrenciaConsultaEntity : IPlanoRecorrenciaConsultaEntity
{
    public string? Id { get; set; }
    public int ProfissionalId { get; set; }
    public string Plano { get; set; }
    public string? ConfirmacaoHash { get; set; }
    public string? Resultado { get; set; }
    public DateTime ExpiraEmUtc { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal PlanoRecorrenciaConsultaEntity(string? id, int profissionalid, string plano, string? confirmacaohash, string? resultado, DateTime expiraemutc ){
 Id = id; 
 ProfissionalId = profissionalid; 
 Plano = plano; 
 ConfirmacaoHash = confirmacaohash; 
 Resultado = resultado; 
 ExpiraEmUtc = (expiraemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : expiraemutc; 
 Deleted = false; 
 Changed = DateTime.Now; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Plano))
   this._erroMensagem.Add("Prévia deve ser informado.");
   if(ExpiraEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Validade da prévia deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration